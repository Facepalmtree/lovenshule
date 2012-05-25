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
        List<TransparentAnimatedFuck> moleBonusImages = new List<TransparentAnimatedFuck>();
        Thread main;          // Kick off a new thread
        int health = 100;
        bool bonus = false;
        int bonusColor = 0;
        int bonusTimer;
        int nextCol;

        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);

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

        //Adds the appropriate image data, for a mole, to the given object.
        private void AddMoleData(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            transparentAnimatedFuck.AddAnimationData(0, 0, false);
            transparentAnimatedFuck.AddAnimationData(1, 14, false);
            transparentAnimatedFuck.AddAnimationData(15, 15, false);
            transparentAnimatedFuck.AddAnimationData(16, 20, false);
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
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationattack1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationattack2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationattack3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationattack4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationattack5);
        }



        //Adds the appropriate image data, for a bonus mole, to the given object.
        private void AddBonusMoleData(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            transparentAnimatedFuck.AddAnimationData(0, 0, false);
            transparentAnimatedFuck.AddAnimationData(1, 14, false);
            transparentAnimatedFuck.AddAnimationData(15, 28, false);
            transparentAnimatedFuck.AddAnimationData(29, 42, false);
            transparentAnimatedFuck.AddAnimationData(43, 56, false);
            transparentAnimatedFuck.AddAnimationData(57, 57, false);
            transparentAnimatedFuck.AddAnimationData(58, 58, false);
            transparentAnimatedFuck.AddAnimationData(59, 59, false);
            transparentAnimatedFuck.AddAnimationData(60, 60, false);
            transparentAnimatedFuck.AddImage(Properties.Resources.molehole);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue10);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue11);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue12);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue13);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationblue14);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred10);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred11);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred12);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred13);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationred14);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow10);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow11);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow12);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow13);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellow14);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen10);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen11);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen12);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen13);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreen14);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationdefeated);
        }

        public void Pause()
        {
            _pauseEvent.Reset();
        }

        public void Resume()
        {
            _pauseEvent.Set();
        }










        public void MainLoop()
        {
            bool play = true;
            int Hole;
            int Mole;
            Random random = new Random();
            //The play variable will be set to false, when the loop should be stopped.


            while (play)
            {
                _pauseEvent.WaitOne(Timeout.Infinite);

                if (_shutdownEvent.WaitOne(0))
                    break;

                    //Check if we are in a bonus level. The logic should change based on this fact.
                    if (bonus == false)
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
                            Hole = random.Next(0, moleImages.Count);
                            if (moleImages[Hole].animation == 0)
                            {
                                SelectAnimationCross(moleImages[Hole], 1);
                                Controller.SetSpawnTime(Hole, 60);
                            }
                        }

                        UpdateHealthCross(health);
                    }




                    //Logic for bonus levels.
                    else
                    {
                        int n = 0;

                        //Mole logic
                        while (n < moleBonusImages.Count)
                        {
                            //Update the graphics
                            animationStepCross(moleBonusImages[n]);

                            //Update Spawn Timer.
                            if (moleBonusImages[n].animation != 0)
                                if (Controller.UpdateBonusSpawnTime(n))
                                {
                                    SelectAnimationCross(moleBonusImages[n], 0);
                                }
                            n++;
                        }



                        //Spawn new Moles
                        if (random.NextDouble() * 100 < 5)
                        {
                            Hole = random.Next(0, moleBonusImages.Count);
                            Mole = random.Next(0, 4);
                            if (moleBonusImages[Hole].animation == 0)
                            {
                                SelectAnimationCross(moleBonusImages[Hole], Mole + 1);
                                Controller.SetBonusSpawnTime(Hole, 60);
                            }
                        }

                        //Update the color if needed.
                        nextCol -= 1;
                        if (nextCol <= 0)
                        {
                            ChangeBonusColor();
                        }

                        //Update Timer
                        bonusTimer -= 1;
                        if (bonusTimer <= 0)
                        {
                            DeInitializeCross();
                        }
                    }

                //Sleep, to not consume endless CPU power.
                //We know sleeåing os not the most accurate, nor a preferred way of doing it, but it'll do.
                Thread.Sleep(1000 / 30);
            }
        }


        //A function for changing the color for bonus levles. It also resets the timer, to make sure it's done.
        public void ChangeBonusColor()
        {
            Random random = new Random();
            bonusColor = random.Next(0, 4);
            nextCol = random.Next(6 * 30, 8 * 30);

            if (bonusColor == 0)
                pictureBox1.Image = Properties.Resources.BlueTex;
            if (bonusColor == 1)
                pictureBox1.Image = Properties.Resources.RedTex;
            if (bonusColor == 2)
                pictureBox1.Image = Properties.Resources.YellowTex;
            if (bonusColor == 3)
                pictureBox1.Image = Properties.Resources.GreenTex;
        }


        public void initializeBonusLevel()
        {
            //Pause the thread (When deleting and creating new objects, deadlocks can easily occour).
            Pause();

            ChangeBonusColor();
            bonusTimer = 21 * 30;

            bonus = true;
            
            int n = 0;
            while (n < moleImages.Count)
            {
                //Make all the non bouns moles invisible.
                moleImages[n].Visible = false;

                n++;
            }

            moleBonusImages.Add(new TransparentAnimatedFuck(1, 483, 484, 200, 200, 165, 120));
            moleBonusImages.Add(new TransparentAnimatedFuck(1, 683, 484, 200, 200, 165, 120));
            moleBonusImages.Add(new TransparentAnimatedFuck(1, 283, 284, 200, 200, 100, 70));
            moleBonusImages.Add(new TransparentAnimatedFuck(1, 883, 284, 200, 200, 100, 70));

            n = 0;
            while (n < moleBonusImages.Count)
            {
                AddBonusMoleData(moleBonusImages[n]);
                moleBonusImages[n].Click += new EventHandler(MoleDieBonus);
                Controller.NewBonusMole();

                this.Controls.Add(moleBonusImages[n]);
                moleBonusImages[n].BringToFront();
                n++;
            }
            Resume();
        }

        public void deinitializeBonusLevel()
        {
            //Pause the thread (When deleting and creating new objects, deadlocks can easily occour).
            Pause();

            bonus = false;

            int n = 0;

            pictureBox1.Image = Properties.Resources.start;

            while (n < moleImages.Count)
            {
                //Make all the non bouns moles invisible.
                moleImages[n].Visible = true;
                n++;
            }

            n = 0;
            while (n < moleBonusImages.Count)
            {
                //Make all the non bouns moles invisible.
                this.Controls.Remove(moleBonusImages[n]);
                n++;
            }
            //moleBonusImages.Clear();
            Resume();
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

            //Make sure they are uninteractable, when invisible.
            if (transparentAnimatedFuck.Visible)
            {
                int ID = 255;

                //We need the id of the mole, rather than the instance.
                int n = 0;
                while (n < moleImages.Count && ID == 255)
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
        }


        private void MoleDieBonus(object sender, EventArgs e)
        {
            TransparentAnimatedFuck transparentAnimatedFuck = (TransparentAnimatedFuck)sender;
            //Set the value to 255, because we know that this value will never be sued (As there can be no more than 10 holes)
            //And int cannot be null.

            //Make sure they are uninteractable, when invisible.
            if (transparentAnimatedFuck.Visible)
            {
                int ID = 255;

                //We need the id of the mole, rather than the instance.
                int n = 0;
                while (n < moleBonusImages.Count && ID == 255)
                {
                    if (transparentAnimatedFuck == moleBonusImages[n])
                        ID = n;
                    n++;
                }

                if ((transparentAnimatedFuck.animation == 1 && bonusColor == 0) || (transparentAnimatedFuck.animation == 2 && bonusColor == 1) || (transparentAnimatedFuck.animation == 3 && bonusColor == 2) || (transparentAnimatedFuck.animation == 4 && bonusColor == 3))
                {
                    transparentAnimatedFuck.SetAnimation(transparentAnimatedFuck.animation + 4);
                    transparentAnimatedFuck.Refresh();
                    Controller.SetBonusSpawnTime(ID, 15);
                    Controller.AddScore(5);
                    UpdateScoreCross();
                }
                else
                    if (transparentAnimatedFuck.animation == 1 || transparentAnimatedFuck.animation == 2 || transparentAnimatedFuck.animation == 3 || transparentAnimatedFuck.animation == 4 && bonusColor == 3)
                    {
                        deinitializeBonusLevel();
                    }
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

                        Controller.SetSpawnTime(ID, 20);


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

        private void DeInitializeCross()
        {
            if (lblScore.InvokeRequired)
            {
                SetNoneCallBack d = new SetNoneCallBack(DeInitializeCross);
                this.Invoke(d);
            }
            else
            {
                deinitializeBonusLevel();
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
            if (healthBarR.InvokeRequired)
            {
                SetIntCallBack d = new SetIntCallBack(UpdateHealthCross);
                this.Invoke(d, new object[] { health });
            }
            else
            {
                if (health > 0)
                    healthBarR.Width = health * 2;
                else
                {
                    Controller.AddEntry();
                    this.Close();
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            deinitializeBonusLevel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            initializeBonusLevel();
        }
    }
}
