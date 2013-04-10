using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Database : Form
    {
        private string[] datainfo;
        private double[] writedata;
        private double heart;
        private int day, month, year,hour,minute,second;
        private string date, time;
        private Form1 form;

        public Database(double hr, int d, int mon, int y,int h, int min, int s, string d8, string t,double[] data,Form1 frm)
        {
            InitializeComponent();
            heart = hr;
            day = d;
            month = mon;
            year = y;
            hour = h;
            minute = min;
            second = s;
            date = d8;
            time = t;
            writedata = data;
            form = frm;

            datainfo = new string[10008];
            datainfo[0] = month.ToString();
            datainfo[1] = day.ToString();
            datainfo[2] = year.ToString();
            datainfo[3] = hour.ToString();
            datainfo[4] = minute.ToString();
            datainfo[5] = second.ToString();
            datainfo[6] = heart.ToString();
            textBox1.Text = date;
            textBox2.Text = time;
            textBox3.Text = String.Format("{0:0.0}", heart);

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubmitName_Click(object sender, EventArgs e)
        {
            if (NBox.Text != "" )
            {
                string fname = NBox.Text;
                datainfo[7] = fname;
                for (int i = 8; i < 10008; i++)
                {
                    datainfo[i] = writedata[i - 8].ToString();
                }
                string filename = fname + "_" + month + "_" + day + "_" + year + "_" + hour + "_" + minute + "_" + second;
                System.IO.File.WriteAllLines(@"C:\Users\Alex\Desktop\ECG_DATA\" + filename + ".txt", datainfo);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Enter a First and Last Name");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
        }

        private void Database_Load(object sender, EventArgs e)
        {

        }

    }
}
