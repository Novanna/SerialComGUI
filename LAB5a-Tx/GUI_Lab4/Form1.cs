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
        public Form1()
        {
            InitializeComponent();
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

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                if (bunifuSwitch1.Value == true)
                {
                    serialPort1.Write("Terrace ON" + "\n\r");
                    listBox1.Items.Add("Terrace Turn ON!");
                }
                else
                {
                    serialPort1.Write("Terrace OFF" + "\n\r");
                    listBox1.Items.Add("Terrace Turn OFF!");
                }
            }
            else
                MessageBox.Show("Koneksikan PORT!");
        }

        private void bunifuSwitch2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                if (bunifuSwitch2.Value == true)
                {
                    serialPort1.Write("LivingRoom ON" + "\n\r");
                    listBox1.Items.Add("Living Room Turn ON!");
                }
                else
                {
                    serialPort1.Write("LivingRoom OFF" + "\n\r");
                    listBox1.Items.Add("Living Room Turn OFF!");
                }
            }
            else
                MessageBox.Show("Koneksikan PORT!");
           
        }

        private void bunifuSwitch3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                if (bunifuSwitch3.Value == true)
                {
                    serialPort1.Write("Kitchen ON" + "\n\r");
                    listBox1.Items.Add("Kitchen Turn ON!");
                }
                else
                {
                    serialPort1.Write("Kitchen OFF" + "\n\r");
                    listBox1.Items.Add("Kitchen Turn OFF!");
                }
            }
            else
                MessageBox.Show("Koneksikan PORT!");
        }

        private void bunifuSwitch4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                if (bunifuSwitch4.Value == true)
                {
                    serialPort1.Write("Workspace ON" + "\n\r");
                    listBox1.Items.Add("Workspace Turn ON!");
                }
                else
                {
                    serialPort1.Write("Workspace OFF!" + "\n\r");
                    listBox1.Items.Add("Workspace Turn OFF!");
                }
            }
            else
                MessageBox.Show("Koneksikan PORT!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
