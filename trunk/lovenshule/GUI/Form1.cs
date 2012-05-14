using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GUI
{
    public partial class Form1 : Form
    {
        delegate void SetMoleCallBack(bool visible);
        delegate void SetTextCallBack(String text);
        delegate void SetNoneCallBack();
        Thread main;          // Kick off a new thread
        int Points = 0;

        public Form1()
        {
            InitializeComponent();

            main = new Thread(MainLoop);
            main.Start();

            //Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++)
            {
                //textBox1.Text+="x";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Makes the winform run in fullscreen.
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //Hides the curser
            //Commented out until it's needed.
            //Cursor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Mole1_Click(object sender, EventArgs e)
        {
            if (Mole1.Visible == true)
                Points += 5;
            Mole1.Visible = false;
        }

        private void Mole2_Click(object sender, EventArgs e)
        {
            if (Mole2.Visible == true)
                Points += 5;
            Mole2.Visible = false;
        }

        private void Mole3_Click(object sender, EventArgs e)
        {
            if (Mole3.Visible == true)
                Points += 5;
            Mole3.Visible = false;
        }

        private void Mole4_Click(object sender, EventArgs e)
        {
            if (Mole4.Visible == true)
                Points += 5;
            Mole4.Visible = false;
        }

        //TEMP TEMP TEMP TEMP
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Abort();
        }

        public void MainLoop()
        {
            bool play = true;
            int Hole = 0;
            Random random = new Random();
            //The play variable will be false, when the game is quit, to stop our loop.



            while (play)
            {
                Update();
                if (random.NextDouble()*100<5)
                {

                    Hole = random.Next(1, 4);
                    if (Hole == 1)
                        SetMole1(true);
                    else
                        if (Hole == 2)
                            SetMole2(true);
                    else
                        if (Hole == 3)
                            SetMole3(true);
                    else
                         SetMole4(true);
                }

                //Sleep, to not consume endless CPU power.
                Thread.Sleep(1000 / 30);
            }
        }


        // The following functions are all thread callbacks, to
        // Ensure a stable program. The following comment will
        // explain how they function, but are put here, so that
        // to not make you read the same thing over and over.

        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        private void SetMole1(bool Visible)
        {
            if (this.Mole1.InvokeRequired)
            {
                SetMoleCallBack d = new SetMoleCallBack(SetMole1);
                this.Invoke(d, new object[] { Visible });
            }
            else
            {
                this.Mole1.Visible = Visible;
            }
        }

        private void SetMole2(bool Visible)
        {
            if (this.Mole2.InvokeRequired)
            {
                SetMoleCallBack d = new SetMoleCallBack(SetMole2);
                this.Invoke(d, new object[] { Visible });
            }
            else
            {
                this.Mole2.Visible = Visible;
            }
        }

        private void SetMole3(bool Visible)
        {
            if (this.Mole3.InvokeRequired)
            {
                SetMoleCallBack d = new SetMoleCallBack(SetMole3);
                this.Invoke(d, new object[] { Visible });
            }
            else
            {
                this.Mole3.Visible = Visible;
            }
        }

        private void SetMole4(bool Visible)
        {
            if (this.Mole4.InvokeRequired)
            {
                SetMoleCallBack d = new SetMoleCallBack(SetMole4);
                this.Invoke(d, new object[] { Visible });
            }
            else
            {
                this.Mole4.Visible = Visible;
            }
        }

        private void Update()
        {
            if (this.label1.InvokeRequired)
            {
                SetNoneCallBack d = new SetNoneCallBack(Update);
                this.Invoke(d);
            }
            else
            {
                this.label1.Text = Points.ToString();
            }
        }
    }
}
