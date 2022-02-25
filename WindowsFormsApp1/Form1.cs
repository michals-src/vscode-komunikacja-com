using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private SerialPort port = new SerialPort("COM1", 11000);

        private const int WM_DEVIDECHANGE = 0x219;
        private const int WM_DEVIDEARRIVAL = 0x8000;
        private const int WM_DEVICEREMOVECOMPLETE = 0x0004;


        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);

            switch(m.Msg){
                case WM_DEVIDECHANGE:
                    switch ((int)m.WParam)
                    {
                        case WM_DEVIDEARRIVAL:
                            if (comboBox1.SelectedItem != null) {
                                port.PortName = comboBox1.SelectedItem.ToString();
                                try
                                {
                                    port.Open();
                                } catch (Exception) { }
                            }
                            break;
                    }
                break;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                comboBox1.Items.Add("COM" + i.ToString());
            }
            comboBox1.SelectedIndex = 0;
            checkBox4.Checked = true;
            button6.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            while (true)
            {
                if( port.IsOpen )
                {
                    label10.Text = "Port: otwarty " + port.PortName;
                    //richTextBox1.Invoke(new EventHandler(delegate { richTextBox1.AppendText(port.ReadExisting()); }));
                }
                else
                {
                    label10.Text = "Port: zamknięty";
                }
                await Task.Delay(300);
              
            }
        }

        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.Close();
            port.PortName = comboBox1.SelectedItem.ToString();
            try
            {
                port.Open();
            }
            catch (Exception)
            {
                if (comboBox1.SelectedIndex > 18) comboBox1.SelectedIndex = 0;
                else comboBox1.SelectedIndex++;

            }

            button8_Click_1(null, null);
            await Task.Delay(10000);
            button2_Click_1(null, null);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            functionB();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            functionC();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            port.WriteLine("D" + numericUpDown1.Value.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            port.WriteLine("ab");   
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            functionE();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            port.WriteLine("G");
            port.Close();

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
            }
            else if (checkBox4.Checked == false)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }


        void functionA()
        {
            port.WriteLine("A");

        }

        void functionB()
        {
            port.WriteLine("B");
        }
        void functionC()
        {
            port.WriteLine("C");
        }
        void functionE()
        {
            port.WriteLine("E");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            port.WriteLine("G");
        }


        private void button8_Click_1(object sender, EventArgs e)
        {

            port.WriteLine("H");
        }

        private void send_custom_color()
        {
            port.WriteLine("CH" + trackBar1.Value.ToString() + "R" + trackBar2.Value.ToString() + "G" + trackBar3.Value.ToString() + "B");
        }


        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
            button6.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            label8.Text = trackBar2.Value.ToString();
            button6.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {
            label9.Text = trackBar3.Value.ToString();
            button6.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void TrackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            send_custom_color();
        }

        private void TrackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            send_custom_color();
        }

        private void TrackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            send_custom_color();
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            port.Close();
            port.PortName = comboBox1.SelectedItem.ToString();
            try
            {
                port.Open();
            }
            catch (Exception)
            {
                //if (comboBox1.SelectedIndex > 18) comboBox1.SelectedIndex = 0;
                //else comboBox1.SelectedIndex++;

            }

            //button8_Click_1(null, null);
            //await Task.Delay(10000);
            //button2_Click_1(null, null);

        }

    }
}
