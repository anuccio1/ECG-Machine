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
using ZedGraph;

namespace ECGDatabase
{
	
	public partial class Form1 : Form
	{
        private string[] lines;
		private string[] files;
		public Form1()
		{

			InitializeComponent();
            //set default values for time selection
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox11.SelectedIndex = 23;
            comboBox12.SelectedIndex = 59;
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 80;


			files = Directory.GetFiles(@"C:\Users\Alex\Desktop\ECG_DATA");

			foreach (string file in files)
			{
                lines = File.ReadAllLines(file);
              //  string filename = lines[6] + " " + lines[7] + " - " + lines[3] + ":" + lines[4] + ":" + lines[5] +
              //                    " - " + lines[0] + "/" + lines[1] + "/" + lines[2];
				listView1.Items.Add(file);
			   
			}
           

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
            listView1.Clear();
            int starth, startmin, endh, endmin;         //start and ending hours,min,sec
            int startbpm, endbpm;
            DateTime startdate = dateTimePicker1.Value.Date;
            DateTime enddate = dateTimePicker2.Value.Date;

            starth = Convert.ToInt32(comboBox7.SelectedItem.ToString());
            startmin = Convert.ToInt32(comboBox8.SelectedItem.ToString());
            endh = Convert.ToInt32(comboBox11.SelectedItem.ToString());
            endmin = Convert.ToInt32(comboBox12.SelectedItem.ToString());
            startbpm = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            endbpm = Convert.ToInt32(comboBox1.SelectedItem.ToString());

			string f = NameBox.Text;

			foreach (string file in files)
			{
                lines = File.ReadAllLines(file);
                int userh, userm;
                double userbpm;   //user time
                userh = Convert.ToInt32(lines[3]);
                userm = Convert.ToInt32(lines[4]);
                userbpm = Convert.ToDouble(lines[6]);

                DateTime userdate = new DateTime(Convert.ToInt32(lines[2]), Convert.ToInt32(lines[0]), Convert.ToInt32(lines[1]));
                int result1 = DateTime.Compare(userdate, startdate);    //has to be > 0
                int result2 = DateTime.Compare(userdate, enddate);      //has to be < 0


                if ((result1 == 0 && result2 == 0) || (result1 == 0 && result2 < 0) ||              //if dates are valid
                     (result1 > 0 && result2 == 0) || (result1 > 0 && result2 < 0))
                {
                    if ((userh == starth) || (userh == endh))       //compare when hours are equivalent
                    {
                        if ((userm >= startmin) && (userm <= endmin))     //compare minutes
                        {
                            if (string.Compare(f, file.Substring(31, f.Length),true)==0)
                            {
                                if (userbpm >= startbpm && userbpm <= endbpm)
                                {
                                    listView1.Items.Add(file);
                                }
                            }
                        }
                    }//end if for equal hours

                    else if ((userh > starth) && (userh < endh))
                    {
                        if (string.Compare(f, file.Substring(31, f.Length), true) == 0)
                        {
                            if (userbpm >= startbpm && userbpm <= endbpm)
                            {
                                listView1.Items.Add(file);
                            }
                            
                        }
                    }

                }
               
               
			   
			}
			
			

		}

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0){

            string val = listView1.SelectedItems[0].Text;

            foreach (string file in files)
            {
                if (String.Compare(file,val, true) == 0 )
                {
                    ShowGraph(file);
                   
                }
            }
         
        }//end if statement

            }

        private void ShowGraph(string file)
        {
            Graph g = new Graph(file,this);
            this.Hide();
            g.Show();
        }
       
	}
}
