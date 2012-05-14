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
        public Form1()
        {
            InitializeComponent();

            Thread t = new Thread(MainLoop);          // Kick off a new thread
            t.Start();                               // running WriteY()

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
            Mole1.Visible = false;
        }

        private void Mole2_Click(object sender, EventArgs e)
        {
            Mole2.Visible = false;
        }

        private void Mole3_Click(object sender, EventArgs e)
        {
            Mole3.Visible = false;
        }

        private void Mole4_Click(object sender, EventArgs e)
        {
            Mole4.Visible = false;
        }

        public void MainLoop()
        {
            //This variable will be false, when the game is quit, to stop our loop.
            bool play = true;


            while (play)
            {
                //Sleep, to not consume endless CPU power.
                Thread.Sleep(1000 / 1);
            }
        }
    }
}
