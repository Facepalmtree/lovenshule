using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model;
using Interface;

namespace Controller
{
    public class ModelController
    {
        //sessionvariables
        DBController dbcontroller;
        PlayerData currentPlayer = null;
        Highscore highscore = new Highscore();

        //TEST PLAYER
        public void TestPlayer()
        {
            currentPlayer = new PlayerData(100, "trololol", 20, 5);
        }



        //constructor
        public ModelController()
        {
            dbcontroller = new DBController(this);
        }

        //methods
        public void HitMole(/*id på hul*/)
        {

        }

        public void AddEntry()
        {
            //TEST
            TestPlayer();

            try
            {
                DateTime now = DateTime.Now;
                int entryID = dbcontroller.AddEntry(currentPlayer.score, currentPlayer.time, currentPlayer.levelCount, now);

                if (entryID != -1)
                {
                    highscore.AddEntry(new Entry(currentPlayer.score, currentPlayer.time, currentPlayer.levelCount, entryID, now)); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

#region Methods for DBController

        //add entry to model from db
        public void DB_AddEntry(int score, int playTime, int levelCount, int entryID, DateTime entryTime)
        {
            try
            {
                highscore.AddEntry(new Entry(score, playTime, levelCount, entryID, entryTime));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

#endregion


        public void LoadHighscore()
        {
            //DBController...
        }
    }
}
