using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ECGDatabase
{
    public partial class Graph : Form
    {
        private string FileName;
        private string[] lines;
        private string[] data;
        private double counter = 0;
        Form1 form;

        public Graph(string file, Form1 f)
        {
            InitializeComponent();
            
            form = f;
            FileName = file;
            lines = System.IO.File.ReadAllLines(file);
            data = new string[lines.Length - 8];
            for (int i = 8; i < lines.Length; i++)
            {
                data[i - 8] = lines[i];
            }

            textBox1.Text = String.Format("{0:0.0}", lines[6]);

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

            pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.IsVisible = false;

            // PointPairList holds the data for plotting, X and Y arrays 
            PointPairList points = new PointPairList();

            // Add cruves to myPane object
            LineItem myCurve = pane.AddCurve("Heart Rate", points, Color.Red, SymbolType.None);
            IPointListEdit list = myCurve.Points as IPointListEdit;

            foreach (string d in data)
            {
                list.Add(counter, (Convert.ToDouble(d)));
                counter = counter + .02;
            }

            zedGraphControl1.GraphPane.XAxis.Scale.Max = counter;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Refresh();

        }

        private void Graph_Load(object sender, EventArgs e)
        {

        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();

        }

        private void Graph_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
