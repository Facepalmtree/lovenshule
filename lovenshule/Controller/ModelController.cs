using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.IO;
using System.Drawing;


using Model;
using Interface;

namespace Controller
{
    public class ModelController
    {
        //sessionvariables
        DBController dbcontroller;
        PlayerData currentPlayer;
        Highscore highscore = new Highscore();
        

        //TEST PLAYER
        public void TestPlayer()
        {
            currentPlayer = new PlayerData();
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
            try
            {
                DateTime now = DateTime.Now;
                int entryID = dbcontroller.AddEntry(currentPlayer.totalScore, currentPlayer.time, currentPlayer.levelCount, now, currentPlayer.image);

                if (entryID != -1)
                {
                    highscore.AddEntry(new Entry(currentPlayer.totalScore, currentPlayer.time, currentPlayer.levelCount, entryID, now, currentPlayer.image)); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region image to byte not used

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
        //    return  ms.ToArray();
        //}

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        #endregion




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

        public void LoseHealth(int hit)
        {
            currentPlayer.LoseLife(hit);
        }

        public string UpdateHealth()
        {
            return currentPlayer.UpdateHealth();
        }
#region Methods for DBController

        //add entry to model from db
        public void DB_AddEntry(int score, int playTime, int levelCount, int entryID, DateTime entryTime, Image image)
        {
            try
            {
                highscore.AddEntry(new Entry(score, playTime, levelCount, entryID, entryTime, image));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

#endregion


        public void LoadHighscore()
        {
            try
            {
                dbcontroller.GetAllEntries();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //til frmadmin

        public List<IEntry> GetIEntries()
        {
            try
            {
                return highscore.GetIEntries();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
