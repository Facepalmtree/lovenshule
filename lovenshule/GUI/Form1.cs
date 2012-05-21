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
using Interface;

namespace GUI
{
    public partial class Form1 : Form
    {
        delegate void SetMoleCallBack(bool visible);
        delegate void SetTextCallBack(String text);
        delegate void SetTAFCallBack(TransparentAnimatedFuck transparentAnimatedFuck);
        delegate void SetTAFIntCallBack(TransparentAnimatedFuck transparentAnimatedFuck, int anim);
        delegate void SetPicCallBack(PictureBox PicBox);
        delegate void SetIntCallBack(int Health);
        delegate void SetNoneCallBack();
        delegate void SetLabelCallBack(Label label, string text);
        List<TransparentAnimatedFuck> moleImages = new List<TransparentAnimatedFuck>();
        Thread main;          // Kick off a new thread
        int health = 100;

        ModelController Controller;

        public Form1(ModelController Controller)
        {
            InitializeComponent();
            this.Controller = Controller;

            moleImages.Add(new TransparentAnimatedFuck(1, 483, 484, 200, 200, 165, 120));
            moleImages.Add(new TransparentAnimatedFuck(1, 683, 484, 200, 200, 165, 120));
            moleImages.Add(new TransparentAnimatedFuck(1, 283, 284, 200, 200, 100, 70));
            moleImages.Add(new TransparentAnimatedFuck(1, 883, 284, 200, 200, 100, 70));

            int n = 0;
            while (n < moleImages.Count)
            {
                AddMoleData(moleImages[n]);
                moleImages[n].Click += new EventHandler(MoleDie);
                Controller.NewMole();

                this.Controls.Add(moleImages[n]);
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
            this.WindowState = FormWindowState.Maximized;

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

        //Adds the appropriate image data, for a mole, to the given object.
        private void AddMoleData(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            transparentAnimatedFuck.AddAnimationData(0, 0, false);
            transparentAnimatedFuck.AddAnimationData(1, 14, false);
            transparentAnimatedFuck.AddAnimationData(15, 15, false);
            transparentAnimatedFuck.AddAnimationData(16, 16, false);
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
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred14);
        }










        public void MainLoop()
        {
            bool play = true;
            int Hole = 0;
            Random random = new Random();
            //The play variable will be set to false, when the loop should be stopped.


            while (play)
            {
                int n = 0;

                //Mole logic
                while (n < moleImages.Count)
                {
                    //Update the graphics
                    animationStepCross(moleImages[n]);

                    //Update Spawn Timer.
                    if (moleImages[n].animation == 1 || moleImages[n].animation == 2 || moleImages[n].animation == 3)
                        if (Controller.UpdateSpawnTime(n))
                        {
                            MoleDespawnCross(moleImages[n]);
                        }
                    n++;
                }



                //Spawn new Moles
                if (random.NextDouble() * 100 < 5)
                {
                    Hole = random.Next(0, 4);
                    if (moleImages[Hole].animation == 0)
                    {
                        SelectAnimationCross(moleImages[Hole], 1);
                        Controller.SetSpawnTime(Hole, 60);
                    }
                }

                UpdateHealthCross(health);

                //Sleep, to not consume endless CPU power.
                Thread.Sleep(1000/30);
            }
        }








        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Abort();
        }

        private void MoleDie(object sender, EventArgs e)
        {
            TransparentAnimatedFuck transparentAnimatedFuck = (TransparentAnimatedFuck)sender;
            //Set the value to 255, because we know that this value will never be sued (As there can be no more than 10 holes)
            //And int cannot be null.
            int ID=255;

            //We need the id of the mole, rather than the instance.
            int n = 0;
            while (n < moleImages.Count && ID==255)
            {
                if (transparentAnimatedFuck == moleImages[n])
                    ID = n;
                n++;
            }

            if (transparentAnimatedFuck.animation == 1)
            {
                transparentAnimatedFuck.SetAnimation(2);
                transparentAnimatedFuck.Refresh();
                Controller.SetSpawnTime(ID, 15);
                Controller.AddScore(5);
                UpdateScoreCross();
            }
        }

        // The following functions are all thread callbacks, to
        // Ensure a stable program. The following comment will
        // explain how they function, but are put here, so that
        // to not make you read the same thing over and over.

        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.



        private void MoleDespawnCross(TransparentAnimatedFuck transparentAnimatedFuck)
        {

            if (transparentAnimatedFuck.InvokeRequired)
            {
                SetTAFCallBack d = new SetTAFCallBack(MoleDespawnCross);
                this.Invoke(d, new object[] { transparentAnimatedFuck });
            }
            else
            {
                if (transparentAnimatedFuck.animation == 3 || transparentAnimatedFuck.animation == 2)
                {

                    if (transparentAnimatedFuck.animation == 3)
                    {
                        int ID = 255;
                        int n = 0;
                        while (n < moleImages.Count && ID==255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }
                        health -= Controller.getUnit(ID).Damage;
                    }
                    transparentAnimatedFuck.SetAnimation(0);
                    transparentAnimatedFuck.Refresh();
                }
                else
                    if (transparentAnimatedFuck.animation == 1)
                    {
                        int ID = 255;
                        int n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SetSpawnTime(ID, 15);


                        transparentAnimatedFuck.SetAnimation(3);
                        transparentAnimatedFuck.Refresh();
                    }
            }
        }

        private void UpdateScoreCross()
        {
            if (lblScore.InvokeRequired)
            {
                SetNoneCallBack d = new SetNoneCallBack(UpdateScoreCross);
                this.Invoke(d);
            }
            else
            {
                lblScore.Text = Convert.ToString(Controller.GetCurrentPlayer().totalScore);
            }
        }

        private void animationStepCross(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            if (transparentAnimatedFuck.InvokeRequired)
            {
                SetTAFCallBack d = new SetTAFCallBack(animationStepCross);
                this.Invoke(d, new object[] { transparentAnimatedFuck });
            }
            else
            {
                if (transparentAnimatedFuck.AnimationStep())
                    updateCross(transparentAnimatedFuck);
            }
        }

        private void SelectAnimationCross(TransparentAnimatedFuck transparentAnimatedFuck, int anim)
        {
            if (transparentAnimatedFuck.InvokeRequired)
            {
                SetTAFIntCallBack d = new SetTAFIntCallBack(SelectAnimationCross);
                this.Invoke(d, new object[] { transparentAnimatedFuck, anim });
            }
            else
            {
                transparentAnimatedFuck.SetAnimation(anim);
                updateCross(transparentAnimatedFuck);
            }
        }

        private void UpdateHealthCross(int health)
        {
            if (healthBar.InvokeRequired)
            {
                SetIntCallBack d = new SetIntCallBack(UpdateHealthCross);
                this.Invoke(d, new object[] { health });
            }
            else
            {
                healthBar.Value = health;
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


        private void updateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelCallBack d = new SetLabelCallBack(updateLabel);
                this.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
