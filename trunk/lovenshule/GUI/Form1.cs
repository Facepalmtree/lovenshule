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
        List<int> IDCollection = new List<int>();
        List<int> IDBonusCollection = new List<int>();
        Thread main;          // Kick off a new thread
        bool bonus = false;
        int bonusColor = 0;
        int bonusTimer;
        int nextCol;
        bool levelEnded = false;
        int nextLevelWait;
        bool bonusSpawned = false;
        int bonusDecay;

        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        ModelController Controller;

        //The form constructor.
        public Form1(ModelController Controller)
        {
            InitializeComponent();
            this.Controller = Controller;

            //This list is made to temporarely get the possible X and Y coordinates for the holes.
            List<int> xCoordinates = new List<int>();
            List<int> yCoordinates = new List<int>();

            //here we actually add some values to them.
            int n = 0;
            while (n < Controller.GetCoordinatesSize())
            {

                xCoordinates.Add(Controller.GetXCoordinates(n));
                yCoordinates.Add(Controller.GetYCoordinates(n));
                n++;
            }

            //here we create new holes, and add random positions to them. These positions are found the the array earlier talked about
            int position;
            n = 0;
            Random random = new Random();
            while (n < Controller.GetHoleCount())
            {
                position = random.Next(0, xCoordinates.Count-1);
                if (yCoordinates[position]==284)
                    moleImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 100, 70));
                else
                    moleImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 165, 120));
                xCoordinates.RemoveAt(position);
                yCoordinates.RemoveAt(position);
                n++;
            }

            /*Here we do the stuff, that needs to be done to each hole, like adding them to the actual form
             * and setting up the id collection list, which will remember the unit ID of the unit in the hole
             * This needs to be reworked into the actual hoel class having these variables.
             */
            n = 0;
            while (n < moleImages.Count)
            {
                AddMoleData(moleImages[n]);
                moleImages[n].Click += new EventHandler(MoleDie);
                IDCollection.Add(255);

                this.Controls.Add(moleImages[n]);
                moleImages[n].BringToFront();
                n++;
            }


            
            //here we start the thread, which will be responsible for the main loop.
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
            Cursor.Hide();
        }

        //Adds the appropriate image data, for a mole, to the given object.
        private void AddMoleData(TransparentAnimatedFuck transparentAnimatedFuck)
        {
            transparentAnimatedFuck.AddAnimationData(0, 0, false);

            transparentAnimatedFuck.AddAnimationData(1, 14, false);
            transparentAnimatedFuck.AddAnimationData(15, 15, false);
            transparentAnimatedFuck.AddAnimationData(16, 20, false);

            transparentAnimatedFuck.AddAnimationData(21, 24, false);
            transparentAnimatedFuck.AddAnimationData(25, 37, false);
            transparentAnimatedFuck.AddAnimationData(38, 41, false);

            transparentAnimatedFuck.AddAnimationData(42, 48, false);
            transparentAnimatedFuck.AddAnimationData(49, 49, false);
            transparentAnimatedFuck.AddAnimationData(50, 58, false);

            transparentAnimatedFuck.AddAnimationData(59, 67, false);
            transparentAnimatedFuck.AddAnimationData(68, 68, false);
            transparentAnimatedFuck.AddAnimationData(69, 74, false);

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

            transparentAnimatedFuck.AddImage(Properties.Resources.bomb1);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb2);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb3);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb4);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation1);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation2);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation3);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation4);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation5);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation6);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation7);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation8);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation9);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation10);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation11);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation12);
            transparentAnimatedFuck.AddImage(Properties.Resources.bombdetonation13);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb4);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb3);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb2);
            transparentAnimatedFuck.AddImage(Properties.Resources.bomb1);

            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrong7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationstrongattack9);

            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat6);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat7);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat8);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfat9);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack1);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack2);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack3);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack4);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack5);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationfatattack6);
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
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationbluedefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationreddefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationyellowdefeated);
            transparentAnimatedFuck.AddImage(Properties.Resources.moleanimationgreendefeated);
        }

        //Pauses the main thrread.
        public void Pause()
        {
            _pauseEvent.Reset();
        }

        //Resumes the main thread.
        public void Resume()
        {
            _pauseEvent.Set();
        }









        //The function which is used as the main thread.
        public void MainLoop()
        {
            bool play = true;
            int Hole;
            int Mole;
            Random random = new Random();
            //The play variable will be set to false, when the loop should be stopped.


            while (play)
            {
                //This is used to pause the thread (Which can be important when we need to add new objects to a list).
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
                            if (moleImages[n].animation == 1 || moleImages[n].animation == 2 || moleImages[n].animation == 3 || moleImages[n].animation == 4 || moleImages[n].animation == 5 || moleImages[n].animation == 6 || moleImages[n].animation == 7 || moleImages[n].animation == 8 || moleImages[n].animation == 9 || moleImages[n].animation == 10 || moleImages[n].animation == 11 || moleImages[n].animation == 12)
                                if (Controller.UpdateSpawnTime(IDCollection[n]))
                                {
                                    //If the Update function returns true, Despawn the mole.
                                    MoleDespawnCross(moleImages[n]);
                                }
                            n++;
                        }


                        //If the bonus start icon is present, count down to make it decay.
                        if (pictureBox1.Visible == true)
                        {
                            bonusDecay -= 1;
                            if (bonusDecay <= 0)
                                //If the bonus icon's count down timer reaches 0 before it is clicked, despawn it again.
                                BonusVisibleCross(false);
                        }



                        //Spawn new Moles
                        if (random.NextDouble() * 100 < (double)Controller.GetSpawnFrequency() && levelEnded == false)
                        {
                            //Find a random hole
                            Hole = random.Next(0, moleImages.Count);
                            //Find a random type (This is a roll between 0 and 100, the level class has presets as to what the
                            //Percentage chance of each mole is).
                            int type = random.Next(0, 101);
                            //If the chosen hole is empty.
                            if (moleImages[Hole].animation == 0)
                            {
                                //All the if and else functions check to see which kind of mole should be spawned.
                                //This is more functional with of/then/else, than with switch, seeing as we need all
                                //The elses for this to work properly.
                                if (type <= Controller.GetCurrentPlayer().GetChanceNormal())
                                {
                                    //Spawn a normal mole, and add the appropriate data.
                                    Controller.NewUnit(1);
                                    IDCollection[Hole] = Controller.GetUnitCount() - 1;
                                    Controller.SetSpawnTime(IDCollection[Hole], Controller.getUnit(IDCollection[Hole]).SpawnTime );
                                    SelectAnimationCross(moleImages[Hole], 1);
                                }
                                else
                                    if (type <= Controller.GetCurrentPlayer().GetChanceNormal() + Controller.GetCurrentPlayer().GetChanceBomb())
                                    {
                                        //Spawn a bomb, and add the appropriate data.
                                        Controller.NewUnit(2);
                                        IDCollection[Hole] = Controller.GetUnitCount() - 1;
                                        Controller.SetSpawnTime(IDCollection[Hole], Controller.getUnit(IDCollection[Hole]).SpawnTime);
                                        SelectAnimationCross(moleImages[Hole], 4);
                                    }
                                    else
                                        if (type <= Controller.GetCurrentPlayer().GetChanceNormal() + Controller.GetCurrentPlayer().GetChanceBomb() + Controller.GetCurrentPlayer().GetChanceStrong())
                                        {
                                            //Spawn a strong mole, and add the appropriate data.
                                            Controller.NewUnit(3);
                                            IDCollection[Hole] = Controller.GetUnitCount() - 1;
                                            Controller.SetSpawnTime(IDCollection[Hole], Controller.getUnit(IDCollection[Hole]).SpawnTime);
                                            SelectAnimationCross(moleImages[Hole], 7);
                                        }
                                        else
                                            if (type <= Controller.GetCurrentPlayer().GetChanceNormal() + Controller.GetCurrentPlayer().GetChanceBomb() + Controller.GetCurrentPlayer().GetChanceStrong() + Controller.GetCurrentPlayer().GetChanceFat())
                                            {
                                                //Spawn a fat mole, and add the appropriate data.
                                                Controller.NewUnit(4);
                                                IDCollection[Hole] = Controller.GetUnitCount() - 1;
                                                Controller.SetSpawnTime(IDCollection[Hole], Controller.getUnit(IDCollection[Hole]).SpawnTime);
                                                SelectAnimationCross(moleImages[Hole], 10);
                                            }
                            }
                        }
                        else
                            //The following logic is for when the level has ended.
                            if (levelEnded == true)
                            {
                                n = 0;
                                bool ok = true;

                                //Check if every hole is empty (We don't want to go to the next level before all the holes are empty.
                                while (n < moleImages.Count)
                                {
                                    if (moleImages[n].animation != 0)
                                        ok = false;
                                    n++;
                                }

                                //if they are
                                if (ok == true)
                                {
                                    //Update the timer and check if enough time has passed.
                                    nextLevelWait -= 1;
                                    if (nextLevelWait <= 0)
                                    {
                                        //If true, start the next level.
                                        StartLevelCross();
                                    }
                                }
                            }
                        //Update the health visually.
                        UpdateHealthCross(Controller.GetCurrentPlayer().health);
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
                                if (Controller.UpdateBonusSpawnTime(IDBonusCollection[n]))
                                {
                                    SelectAnimationCross(moleBonusImages[n], 0);
                                }
                            n++;
                        }



                        //Spawn new Moles
                        if (random.NextDouble() * 100 < 5)
                        {
                            //Choose a random hole, and a random coloured mole
                            Hole = random.Next(0, moleBonusImages.Count);
                            Mole = random.Next(0, 4);
                            //If the chosen hole is empty
                            if (moleBonusImages[Hole].animation == 0)
                            {
                                //Make a bonus unit, and assign the correct attributes.
                                Controller.NewUnit(5);
                                IDBonusCollection[Hole] = Controller.GetBonusUnitCount()-1;

                                SelectAnimationCross(moleBonusImages[Hole], Mole + 1);
                                Controller.SetBonusSpawnTime(IDBonusCollection[Hole], Controller.getBonusUnit(IDBonusCollection[Hole]).SpawnTime);
                            }
                        }

                        //Update the color if needed.
                        nextCol -= 1;
                        updateLabelCross(lblBonusCount, Convert.ToString(Math.Floor((decimal)nextCol / 30)+1));
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
                //We know sleeping os not the most accurate, nor a preferred way of doing it, but it'll do.
                Thread.Sleep(1000 / 30);
            }
        }


        //A function for changing the color for bonus levels. It also resets the timer, to make sure it's done.
        public void ChangeBonusColor()
        {
            Random random = new Random();
            bonusColor = random.Next(0, 4);
            nextCol = random.Next(6 * 30, 8 * 30);

            if (bonusColor == 0)
                pictureBox1.Image = Properties.Resources.TexBlue;
            if (bonusColor == 1)
                pictureBox1.Image = Properties.Resources.TexRed;
            if (bonusColor == 2)
                pictureBox1.Image = Properties.Resources.TexYellow;
            if (bonusColor == 3)
                pictureBox1.Image = Properties.Resources.TexGreen;
        }

        //A function that initializes the bonus level.
        public void initializeBonusLevel()
        {
            //Pause the thread (When deleting and creating new objects, deadlocks can easily occour).
            Pause();

            ChangeBonusColor();
            bonusTimer = 21 * 30;

            bonus = true;
            
            //For each mole:
            int n = 0;
            while (n < moleImages.Count)
            {
                //Make all the non bouns moles invisible.
                moleImages[n].Visible = false;

                n++;
            }

            //A temporarily list. to store the possible X and Y values for holes.
            List<int> xCoordinates = new List<int>();
            List<int> yCoordinates = new List<int>();

            //Add the appropriate data to the list.
            n = 0;
            while (n < Controller.GetCoordinatesSize())
            {

                xCoordinates.Add(Controller.GetXCoordinates(n));
                yCoordinates.Add(Controller.GetYCoordinates(n));
                n++;
            }

            //Add the holes, to random chosen X and Y values, based on the previous list.
            int position;
            n = 0;
            Random random = new Random();
            while (n < Controller.GetHoleCount())
            {
                position = random.Next(0, xCoordinates.Count - 1);
                if (yCoordinates[position] == 284)
                    moleBonusImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 100, 70));
                else
                    moleBonusImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 165, 120));
                xCoordinates.RemoveAt(position);
                yCoordinates.RemoveAt(position);
                n++;
            }

            //Do what needs to be done with the holes, like add them to the form and, adding an entry in the IDcollection.
            n = 0;
            while (n < moleBonusImages.Count)
            {
                AddBonusMoleData(moleBonusImages[n]);
                moleBonusImages[n].Click += new EventHandler(MoleDieBonus);
                IDBonusCollection.Add(255);

                this.Controls.Add(moleBonusImages[n]);
                moleBonusImages[n].BringToFront();
                n++;
            }

            lblBonusCount.Visible = true;

            Resume();
        }

        //Function to deinitialize a bonus level.
        public void deinitializeBonusLevel()
        {
            //Pause the thread (When deleting and creating new objects, deadlocks can easily occour).
            Pause();

            bonus = false;

            //Revert the picturebox back to the logo, so that once it needs to be made visible again, the sprite is already buffered.
            pictureBox1.Image = Properties.Resources.Star_løve1_small;
            pictureBox1.Visible = false;

            int n = 0;
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
            moleBonusImages.Clear();

            lblBonusCount.Visible = false;
            IDBonusCollection.Clear();
            Resume();
        }




        //Make sure that if the window is closed in a non-optimal manner, the thread is also terminated.
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Abort();
        }

        //Function called whenever a mole dies.
        private void MoleDie(object sender, EventArgs e)
        {
                TransparentAnimatedFuck transparentAnimatedFuck = (TransparentAnimatedFuck)sender;

                //Make sure they are uninteractable, when invisible.
                if (transparentAnimatedFuck.Visible)
                {
                    Random random = new Random();
                    //Set the value to 255, because we know that this value will never be used (As there can be no more than 10 holes)
                    //And int cannot be null.
                    int ID = 255;

                    //We need the id of the mole, rather than the instance.
                    int n = 0;
                    while (n < moleImages.Count && ID == 255)
                    {
                        if (transparentAnimatedFuck == moleImages[n])
                            ID = n;
                        n++;
                    }
                    //Reduce the health of the mole, and if it's out of health, run some code.
                    if (Controller.reduceHealth(IDCollection[ID]))
                    {
                        //If it's one of the moles to add points
                        if (transparentAnimatedFuck.animation == 1 || transparentAnimatedFuck.animation == 7 || transparentAnimatedFuck.animation == 10)
                        {
                            //First, there's a 2% chance to to spawn the lion head, giving entrance to the bonus level.
                            if (random.NextDouble() * 100 <= 2 && bonusSpawned == false)
                            {
                                pictureBox1.Visible = true;
                                bonusSpawned = true;
                                bonusDecay = 45;
                            }

                            //Set the animation to the death animation
                            transparentAnimatedFuck.SetAnimation(transparentAnimatedFuck.animation + 1);
                            transparentAnimatedFuck.Refresh();
                            Controller.SetSpawnTime(IDCollection[ID], 15);

                            //Add the score, and update the label.
                            Controller.AddScore(Controller.getUnit(IDCollection[ID]).Point);
                            UpdateScoreCross();
                        }
                        else
                            //If it's a bomb, do some other logic:
                            if (transparentAnimatedFuck.animation == 4)
                            {
                                //Chance the animation
                                transparentAnimatedFuck.SetAnimation(5);
                                transparentAnimatedFuck.Refresh();
                                Controller.SetSpawnTime(IDCollection[ID], 15);
                            }
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

                //Reduce the health of the bonus mole, and, if it's out of health, proceed to the next code.
                if (Controller.reduceHealthBonus(IDBonusCollection[ID]))
                {
                    //First, check if it was the correct mole we hit.
                    if ((transparentAnimatedFuck.animation == 1 && bonusColor == 0) || (transparentAnimatedFuck.animation == 2 && bonusColor == 1) || (transparentAnimatedFuck.animation == 3 && bonusColor == 2) || (transparentAnimatedFuck.animation == 4 && bonusColor == 3))
                    {
                        //If yes change the animation.
                        transparentAnimatedFuck.SetAnimation(transparentAnimatedFuck.animation + 4);
                        transparentAnimatedFuck.Refresh();
                        Controller.SetBonusSpawnTime(IDBonusCollection[ID], 15);

                        //And add the points.
                        Controller.AddScore(Controller.getUnit(IDBonusCollection[ID]).Point);
                        UpdateScoreCross();
                    }
                    else
                        //If not, deinitialize the level.
                        if ((transparentAnimatedFuck.animation == 1 && bonusColor != 1) || (transparentAnimatedFuck.animation == 2 && bonusColor != 2) || (transparentAnimatedFuck.animation == 3 && bonusColor != 3) || (transparentAnimatedFuck.animation == 4 && bonusColor != 4))
                        {
                            deinitializeBonusLevel();
                        }
                }
            }
        }

        //Function to end the level.
        public void EndLevel()
        {
            levelEnded = true;
            nextLevelWait = 5 * 30;

            //Remove all holes from the form.
            int n = 0;
            while (n < moleImages.Count)
            {
                this.Controls.Remove(moleImages[n]);
                n++;
            }

            //Clear all the data to free the RAM.
            moleImages.Clear();
            IDCollection.Clear();
            PicBNextLevel.Visible = true;
        }

        //Function to start the level.
        public void StartLevel()
        {
            levelEnded = false;
            Controller.Nextlevel();

            //Make two new lists to hold the X and Y variables for the holes.
            List<int> xCoordinates = new List<int>();
            List<int> yCoordinates = new List<int>();

            //Add the appropriate variables to the lists.
            int n = 0;
            while (n < Controller.GetCoordinatesSize())
            {
                
                xCoordinates.Add(Controller.GetXCoordinates(n));
                yCoordinates.Add(Controller.GetYCoordinates(n));
                n++;
            }

            //Choose some random positions, and spawn holes there, based on the before mentioned lists.
            int position;
            n = 0;
            Random random = new Random();
            while (n < Controller.GetHoleCount())
            {
                position = random.Next(0, xCoordinates.Count - 1);
                if (yCoordinates[position] == 284)
                    moleImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 100, 70));
                else
                    moleImages.Add(new TransparentAnimatedFuck(1, xCoordinates[position], yCoordinates[position], 200, 200, 165, 120));
                xCoordinates.RemoveAt(position);
                yCoordinates.RemoveAt(position);
                n++;
            }

            //Do the needed procedures to the holes, like adding them to the form and seting up the appropriate data.
            n = 0;
            while (n < moleImages.Count)
            {
                AddMoleData(moleImages[n]);
                moleImages[n].Click += new EventHandler(MoleDie);
                IDCollection.Add(255);

                this.Controls.Add(moleImages[n]);
                moleImages[n].BringToFront();
                n++;
            }

            bonusSpawned = false;
            PicBNextLevel.Visible = false;
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
                int ID = 255;
                int n = 0;
                //When despawning the mole, we need to do some logic, based on the actual mole, and animation.
                //Mole numbers: 1, 4, 7, 10 means that the mole should begin the attack.
                //Mole numbers: 2, 5, 8, 11 means that the mole should just be despawned (if it's a bomb (number 5) it should also substract score).
                //Mole numbers: 3, 6, 9, 12 means that the mole should first deal damage, then despawn.
                switch (transparentAnimatedFuck.animation)
                {
                    case 3:
                    case 2:
                        if (transparentAnimatedFuck.animation == 3)
                        {
                            ID = 255;
                            n = 0;
                            while (n < moleImages.Count && ID == 255)
                            {
                                if (transparentAnimatedFuck == moleImages[n])
                                    ID = n;
                                n++;
                            }
                            Controller.LoseHealth(Controller.getUnit(IDCollection[ID]).Damage);
                        }

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                    break;
                    case 1:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SetSpawnTime(IDCollection[ID], 20);


                        transparentAnimatedFuck.SetAnimation(3);
                        transparentAnimatedFuck.Refresh();
                    break;
                    case 4:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SetSpawnTime(IDCollection[ID], 5);


                        transparentAnimatedFuck.SetAnimation(6);
                        transparentAnimatedFuck.Refresh();
                    break;
                    case 5:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SubstractScore(Controller.getUnit(IDCollection[ID]).Point);
                        UpdateScoreCross();

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                    break;
                    case 6:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                        break;
                    case 7:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SetSpawnTime(IDCollection[ID], 20);


                        transparentAnimatedFuck.SetAnimation(9);
                        transparentAnimatedFuck.Refresh();
                    break;
                    case 8:
                        UpdateScoreCross();

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                    break;
                    case 9:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }
                        Controller.LoseHealth(Controller.getUnit(IDCollection[ID]).Damage);

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                        break;
                    case 10:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }

                        Controller.SetSpawnTime(IDCollection[ID], 20);


                        transparentAnimatedFuck.SetAnimation(12);
                        transparentAnimatedFuck.Refresh();
                        break;
                    case 11:
                        UpdateScoreCross();

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                        break;
                    case 12:
                        ID = 255;
                        n = 0;
                        while (n < moleImages.Count && ID == 255)
                        {
                            if (transparentAnimatedFuck == moleImages[n])
                                ID = n;
                            n++;
                        }
                        Controller.LoseHealth(Controller.getUnit(IDCollection[ID]).Damage);

                        transparentAnimatedFuck.SetAnimation(0);
                        transparentAnimatedFuck.Refresh();

                        if (levelEnded == false)
                            if (Controller.SpawnDecrease())
                            {
                                EndLevel();
                            }
                        break;
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

        private void StartLevelCross()
        {
            SetNoneCallBack d = new SetNoneCallBack(StartLevel);
            this.Invoke(d);
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


        private void updateLabelCross(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelCallBack d = new SetLabelCallBack(updateLabelCross);
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

        private void BonusVisibleCross(bool visible)
        {
            if (pictureBox1.InvokeRequired)
            {
                SetMoleCallBack d = new SetMoleCallBack(BonusVisibleCross);
                this.Invoke(d, new object[] { visible });
            }
            else
            {
                pictureBox1.Visible = visible;
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
            if (pictureBox1.Visible == true)
            {
                initializeBonusLevel();
            }
        }
    }
}