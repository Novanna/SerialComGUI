using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Lab4
{
    public partial class Form1 : Form
    {
        Image TOFF = Properties.Resources.Button_Blank_Gray_icon;
        Image TON = Properties.Resources.Button_Blank_Green_icon;
        Image LOFF = Properties.Resources.Button_Blank_Gray_icon;
        Image LON = Properties.Resources.Button_Blank_Green_icon;
        Image KOFF = Properties.Resources.Button_Blank_Gray_icon;
        Image KON = Properties.Resources.Button_Blank_Green_icon;
        Image WOFF = Properties.Resources.Button_Blank_Gray_icon;
        Image WON = Properties.Resources.Button_Blank_Green_icon;

        public Form1()
        {
            InitializeComponent();
            Terrace.Image = TON;
            LivingRoom.Image = LOFF;
            Kitchen.Image = KON;
            Workspace.Image = WOFF;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] portList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (String portName in portList)
                comboBox1.Items.Add(portName);

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
            serialPort1.Open();
            Form1.ActiveForm.Text = serialPort1.PortName + " is connected";
            button1.Enabled = false;
/*
            timer1.Enabled = !(timer1.Enabled);
            if (serialPort1.IsOpen)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Form1.ActiveForm.Text = "Serial Communication";
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Tampilkan(serialPort1.ReadExisting());
        }
        
        private delegate void TampilkanDelegate(object item);
        private void Tampilkan(object item)
        {
            if (InvokeRequired)
            // This is a worker thread so delegate the task.
            listBox1.Invoke(new TampilkanDelegate(Tampilkan), item);
            else
            // This is the UI thread so perform the task.
            listBox1.Items.Add(item);
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string[] myPort;
            myPort = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.AddRange(myPort);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void stateIndicatorGauge6_Changed(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Ton_Click(object sender, EventArgs e)
        {

        }

        private void Ton_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Toff_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (listBox1.Text.ToUpper() == "Terrace ON")
                {
                    Terrace.Image = TON;
                }

                if (listBox1.Text.ToUpper() == "LivingRoom ON")
                {
                    LivingRoom.Image = LON;
                }
                
                if (listBox1.Text.ToUpper() == "Kitchen ON")
                {
                    Kitchen.Image = KON;
                }

                if (listBox1.Text.ToUpper() == "Workspace ON")
                {
                    Workspace.Image = WON;
                }

                if (listBox1.Text.ToUpper() == "Terrace OFF")
                {
                    Terrace.Image = TOFF;
                }

                if (listBox1.Text.ToUpper() == "LivingRoom OFF")
                {
                    LivingRoom.Image = LOFF;
                }

                if (listBox1.Text.ToUpper() == "Kitchen OFF")
                {
                    Kitchen.Image = KOFF;
                }

                if (listBox1.Text.ToUpper() == "Workspace OFF")
                {
                    Workspace.Image = WOFF;
                }
            }
        }
    }
}
