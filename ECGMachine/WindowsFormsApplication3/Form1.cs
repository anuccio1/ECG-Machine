using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;

namespace WindowsFormsApplication3
{

    public partial class Form1 : Form
    {
        private SerialPort port;
        private static int tickStart = 0;  //timer
        private double counter = 0;
        private int addindex = 0;
        private double[] datasend = new double[10000];
        private static ArrayList portdata;
        private Thread newthread;
        private Thread beepthread;
        private Thread OLthread;
        private Thread qrsthread;
        private Thread threshdecrement;
        private Boolean beeper = false;
        private double qrsaverage = 0;
        private double finitedif = 0;
        private double thresh = 10;
        private double[] qrs = new double[10];          //qrs detection array
        private double[] recentd = new double[150];     //overload detection array
        private double[] lowarray = new double[150];
        private double[] higharray = new double[150];
        private Boolean gainselect = false;
        private double heartbeat = 0;
        private DateTime oldbeep = DateTime.Now;
        private DateTime newbeep = DateTime.Now;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 150; i++)           //overload checker
            {
                lowarray[i] = 0;
            }

            for (int j = 0; j < 150; j++)
            {
                higharray[j] = 1000;
            }

            // This is to remove all plots
            zedGraphControl1.GraphPane.CurveList.Clear();

            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane pane = zedGraphControl1.GraphPane;
           

            //Set up Graph Pane
            pane.Fill.Color = System.Drawing.Color.RoyalBlue;
            pane.Title.Text = "ECG Machine";
            pane.XAxis.Title.Text = "Time (Seconds)";
            pane.YAxis.Title.Text = "Voltage (mV)";
            pane.Legend.IsVisible = false;
            pane.XAxis.Scale.MajorUnit = DateUnit.Millisecond;
            pane.XAxis.Scale.MinorUnit = DateUnit.Millisecond;

            
            zedGraphControl1.GraphPane.XAxis.Scale.Max = 30;
          //  zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
            zedGraphControl1.GraphPane.YAxis.Scale.Max = 1024;
            zedGraphControl1.GraphPane.YAxis.Scale.Min = 0;
            

            zedGraphControl1.IsShowHScrollBar = true;
            zedGraphControl1.IsAutoScrollRange = true;

            zedGraphControl1.AxisChange();

            // PointPairList holds the data for plotting, X and Y arrays 
            PointPairList points = new PointPairList();

            // Add cruves to myPane object
            LineItem myCurve = pane.AddCurve("Heart Rate", points, Color.Red, SymbolType.None);
            
            tickStart = Environment.TickCount;
            portdata = new ArrayList();
            
            
        }

        private void EstablishConnection()
        {
            port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.None;
            port.ReadTimeout = 500;
            port.WriteTimeout = 500;
            if (!(port.IsOpen == true)) port.Open();
            port.Write("B");
            port.Write("D");
            port.Write("E");
        }


        /* This begins data reading from serial Port */
        private void button1_Click(object sender, EventArgs e)
        {
            EstablishConnection();
            button1.Enabled = false;
            pointHP.Select();
            newthread = new Thread(new ThreadStart(this.reader));
            newthread.IsBackground = true;
            newthread.Start();

            beepthread = new Thread(new ThreadStart(this.beepcontrol));
            beepthread.IsBackground = true;
            beepthread.Start();

            OLthread = new Thread(new ThreadStart(this.OLdetection));
            OLthread.IsBackground = true;
            OLthread.Start();

            qrsthread = new Thread(new ThreadStart(this.qrsdetection));
            qrsthread.IsBackground = true;
            qrsthread.Start();

            threshdecrement = new Thread(new ThreadStart(this.threshdec));
            threshdecrement.IsBackground = true;
            threshdecrement.Start();

            timer1.Interval = 1;
            timer1.Enabled = true;
            timer1.Start();     //start timer to add points to chart
            
        }

        private void threshdec()
        {
            while (port.IsOpen)
            {
                if (thresh > 0)
                {
                    if (!gainselect)
                    {
                        thresh = thresh - 1;
                        Thread.Sleep(80);
                    }
                    else
                    {
                        thresh = thresh - 2;
                        Thread.Sleep(20);
                    }
                }
            }
        }

        private void qrsdetection()
        {

            while (port.IsOpen)
            {
                if (addindex > 10)
                {
                    int sum = 0;
                    int C = portdata.Count - 1;
                    for (int i = 0; i < 10; i++)
                    {
                        qrs[i] = (double)portdata[C - (9 - i)];
                    }
                    foreach (int num in qrs)
                    {
                        sum += num;
                    }
                    qrsaverage = sum / 10;          //smooth out signal
                    finitedif = qrs[9] - qrsaverage;
                    if (finitedif > thresh)
                    {
                        thresh = finitedif;
                        if (thresh > 8)
                        {
                            beeper = true;
                        }
                   }
                }

            }
        }

        private void OLdetection()
        {

            while (port.IsOpen)
            {
                if (addindex > 150) {
                int C = portdata.Count - 1;
                

                for (int i = 0; i < recentd.Length; i++)
                {
                    recentd[i] = (double)portdata[C - (149 - i)];
                }

                if (lowcheck(recentd) || highcheck(recentd))
                {
                    setOL("Overload");
                    //set to 5 hp filter
                    Thread.Sleep(150);
                    selectfilter();

                }
                else
                {
                    setOL("");
                }
                
            }
                }
        }

        private void selectfilter()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { selectfilter(); }));
            }
            else
            {
                pointHP.Select();
                pointHP.Enabled = false;
                port.Write("D");
                thresh = 0;
            }
        }

        private void setOL(string text)
        {
            if (this.OverLoad.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<string>(setOL), new object[] { text });
                    return;
                }
                catch (ObjectDisposedException) { }
            }
            try
            {
                OverLoad.Text = text;
            }
            catch (Win32Exception) { }
        }

        private void setHeartRate(double bpm)
        {
            if (this.HeartRate.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<double>(setHeartRate), new object[] { bpm });
                    return;
                }
                catch (ObjectDisposedException) { }
            }
            try
            {
                HeartRate.Text = String.Format("{0:0.0}", bpm);
                   
            }
            catch (Win32Exception) { }
        }

        private void beepcontrol()
        {
            while (port.IsOpen)
            {
                if (beeper)
                {
                    Thread.Sleep(80);   //makes sure it doesnt beep twice within 1/120 sec
                    Console.Beep();
                    //get BPM
                    oldbeep = newbeep;
                    newbeep = DateTime.Now;
                    double span = (newbeep-oldbeep).Milliseconds;
                    heartbeat = 60000 / span;
                    setHeartRate(heartbeat);
                    beeper = false;
                    
                    
                }
            }
        }


        public void reader()
        {
            while (port.IsOpen)
            {

                    double pt;
                    string dat = port.ReadLine();

                    if (Double.TryParse(dat, out pt))           //if data read is a double value
                    {
                        portdata.Add(pt);
                    }

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //make sure curvelist isnt empty
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                return;

            //get first curve in graph
            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (curve == null)
                return;

            IPointListEdit list = curve.Points as IPointListEdit;
 
                if (addindex < portdata.Count)
                {
                    list.Add(counter, (double)portdata[addindex]);

                    addindex = addindex + 20;
                    counter = counter + .02;

                }


            zedGraphControl1.GraphPane.XAxis.Scale.Max = counter + 5;
            zedGraphControl1.GraphPane.XAxis.Scale.Min = zedGraphControl1.GraphPane.XAxis.Scale.Max - 10;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();
        }


        private void NotchBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NotchBox.Checked)
            {
                port.Write("F");
            }
            else
            {
                port.Write("E");
                thresh = 0;
            }
        }

        private void GainBox_CheckedChanged(object sender, EventArgs e)
        {
            thresh = 0;

            if (GainBox.Checked)
            {
                port.Write("A");
                gainselect = true;
            }
            else
            {
                port.Write("B");
                gainselect = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pointHP.Enabled = false;
            fiveHP.Enabled = true;
            port.Write("D");
        }

        private void fiveHP_CheckedChanged(object sender, EventArgs e)
        {
            fiveHP.Enabled = false;
            pointHP.Enabled = true;
            port.Write("C");
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {
            this.Hide();
            int currentday,currentmonth,currentyear,currenthour,currentminute,currentsecond;
            double currentheartrate;
            string currenttime, currentdate;
            currentday = DateTime.Today.Day;
            currentmonth = DateTime.Today.Month;
            currentyear = DateTime.Today.Year;
            currenttime = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            currentdate = DateTime.Now.ToString();
            currenthour = DateTime.Now.Hour;
            currentminute = DateTime.Now.Minute;
            currentsecond = DateTime.Now.Second;
            currentheartrate = heartbeat;

            if (addindex > 9999)
            {
                for (int i = 0; i < 10000; i++)
                {
                    datasend[i] = (double)portdata[portdata.Count - (10000 - i)];
                }

                Database d = new Database(currentheartrate,currentday, currentmonth, currentyear, currenthour, currentminute, currentsecond, currentdate, currenttime, datasend,this);
                //timer1.Stop();
                d.Show();
            }
            else
            {
                MessageBox.Show("Not Enough Data Collected");
                this.Show();
            }
        }

        private Boolean lowcheck(double[] a)
        {
   
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != lowarray[i])
                        return false;
                }
                return true;

        }

        private Boolean highcheck(double[] a)
        {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < higharray[i])
                        return false;
                }
                return true;
        }



        /* Unused methods */
        private void chart1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void zedGraphControl1_Load(object sender, EventArgs e){ }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Overload_TextChanged(object sender, EventArgs e) { }
 



            

    }

}