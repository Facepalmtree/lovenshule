using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Controller;

namespace GUI
{
    public partial class Form1 : Form
    {
        delegate void SetMoleCallBack(bool visible);
        delegate void SetTextCallBack(String text);
        delegate void SetTAFCallBack(TransparentAnimatedFuck transparentAnimatedFuck);
        delegate void SetPicCallBack(PictureBox PicBox);
        delegate void SetNoneCallBack();
        List<TransparentAnimatedFuck> moleImages = new List<TransparentAnimatedFuck>();
        Thread main;          // Kick off a new thread

        ModelController Controller = new ModelController();

        public Form1()
        {
            InitializeComponent();


            moleImages.Add(new TransparentAnimatedFuck(1, 500, 500, 165, 120));
            moleImages.Add(new TransparentAnimatedFuck(1, 700, 500, 165, 120));
            moleImages.Add(new TransparentAnimatedFuck(1, 400, 420, 100, 70));
            moleImages.Add(new TransparentAnimatedFuck(1, 800, 420, 100, 70));

            int n = 0;
            while (n < moleImages.Count)
            {
                AddMoleData(moleImages[n]);

                this.tabPage2.Controls.Add(moleImages[n]);
                moleImages[n].BringToFront();
                n++;
            }


            

            main = new Thread(MainLoop);
            main.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Makes the winform run in fullscreen.
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(-28, -47);

            //Hides the curser
            //Commented out until it's needed.
            //Cursor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        //Adds the appropriate image data, for a mole, to the given object,
        private void AddMoleData(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            transparentAnimatedFuck.AddAnimationData(0, 0);
            transparentAnimatedFuck.AddAnimationData(1, 13);
            transparentAnimatedFuck.AddImage(Properties.Resources.molehole);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation10);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation11);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation12);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation13);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimation14);
        }










        public void MainLoop()
        {
            bool play = true;
            int Hole = 0;
            Random random = new Random();
            //The play variable will be set to false, when the loop should be stopped.



            while (play)
            {
                //Update the graphics
                int n = 0;
                while (n < moleImages.Count)
                {
                    animationStepCross(moleImages[n]);
                    updateCross(moleImages[n]);
                    n++;
                }

                if (random.NextDouble() * 100 < 5)
                {

                    Hole = random.Next(1, 4);
                }

                //Sleep, to not consume endless CPU power.
                Thread.Sleep(1000/30);
            }
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }


        // The following functions are all thread callbacks, to
        // Ensure a stable program. The following comment will
        // explain how they function, but are put here, so that
        // to not make you read the same thing over and over.

        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.

        private void animationStepCross(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            if (transparentAnimatedFuck.InvokeRequired)
            {
                SetTAFCallBack d = new SetTAFCallBack(animationStepCross);
                this.Invoke(d, new object[] { transparentAnimatedFuck });
            }
            else
            {
                transparentAnimatedFuck.AnimationStep();
            }
        }

        private void updateCross(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            if (transparentAnimatedFuck.InvokeRequired)
            {
                SetTAFCallBack d = new SetTAFCallBack(updateCross);
                this.Invoke(d, new object[] { transparentAnimatedFuck });
            }
            else
            {
                transparentAnimatedFuck.Refresh();
            }
        }

        private void updateCross2(PictureBox PicBox)
        {
            if (PicBox.InvokeRequired)
            {
                SetPicCallBack d = new SetPicCallBack(updateCross2);
                this.Invoke(d, new object[] { PicBox });
            }
            else
            {
                PicBox.Refresh();
            }
        }
    }
}
