﻿using System;
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
        PlayerData currentPlayer = new PlayerData(0, "img", 0, 1, 10);
        Highscore highscore = new Highscore();

        //TEST PLAYER
        public void TestPlayer()
        {
            currentPlayer = new PlayerData(100, "trololol", 20, 5, 10);
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
                int entryID = dbcontroller.AddEntry(currentPlayer.totalScore, currentPlayer.time, currentPlayer.levelCount, now);

                if (entryID != -1)
                {
                    highscore.AddEntry(new Entry(currentPlayer.totalScore, currentPlayer.time, currentPlayer.levelCount, entryID, now)); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddScore(int score)
        {
            currentPlayer.AddScore(score);
        }

        public string UpdateScore()
        {
            return currentPlayer.UpdateScore();
        }

        public void GetTime(int time)
        {
            currentPlayer.SaveTime(time);
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
