using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace TempSystem
{
    public partial class Form1 : Form
    {
        SerialPort com = new SerialPort();
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
            ConnectPort();
        }

        public void ConnectPort()
        {
            bool portfound = false;
            //=============================================
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine(s);
                com.Close(); // To handle the exception, in case the port isn't found and then they try again...

                com.PortName = s;
                com.BaudRate = 9600;
                try
                {
                    com.Open();
                    if (com.IsOpen)
                    {
                        portfound = true;
                    }
                }
                catch
                {
                    if (!portfound)
                    {
                        com.Close();
                    }
                }
            }
            //=============================================

            //serialPort = new SerialPort("COM6", 9600);

            //try
            //{
            //    serialPort.Open();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (com.IsOpen)
            {
                string temp = "";
                int iTemp = 0;
                try
                {
                    temp = com.ReadLine();
                    temp = temp.Remove(temp.IndexOf("."), (temp.Length - temp.IndexOf(".")));
                    iTemp = Convert.ToInt32(temp);
                }
                catch
                {
                    temp = "-";
                    iTemp = 0;
                }

                if (iTemp != 0)
                {
                    if (iTemp <= 30)
                    {
                        pictureBox1.Image = global::TempSystem.Properties.Resources.Frio;
                    }
                    else
                    {
                        pictureBox1.Image = global::TempSystem.Properties.Resources.caliente;
                    }
                    label1.Text = "" + iTemp;
                }
            } else
            {
                ConnectPort();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
