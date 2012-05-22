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
        List<Unit> units = new List<Unit>();
        List<Hole> holes = new List<Hole>();

        //constructor
        public ModelController()
        {
            dbcontroller = new DBController(this);
        }

        //Creates new player
        public void NewPlayer(Image image)
        {
            try
            {
                currentPlayer = new PlayerData(image);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // if the units' spawntime is not 0, its subtracts 1 from the spawntime and returns false
        // if it is 0 or less it returns true
        public IUnit getUnit(int ID)
        {
            return (IUnit)units[ID];
        }

        public bool UpdateSpawnTime(int ID)
        {
            if (units[ID].SpawnTime!=0)
            units[ID].SpawnTime -= 1;
            if (units[ID].SpawnTime <= 0) return true; else return false;
        }

        // Gives a value to a units spawntime
        public void SetSpawnTime(int ID, int time)
        {
            units[ID].SpawnTime = time;
        }

        public void NewMole()
        {
            //Creates a new mole.
            units.Add(new UnitNormal());
        }

        public void NewHole()
        {
            //Creates a new hole.
            holes.Add(new Hole());
        }

        //Sets every value in currentPlayer to null
        public void ResetPlayer()
        {
            currentPlayer = null;
        }

        //methods
        public void HitMole(/*id på hul*/)
        {

        }

        public void AddEntry()
        {
            try
            {
                //create an instance of now to get same time in model and db
                DateTime now = DateTime.Now;
                int entryID = dbcontroller.AddEntry(currentPlayer.totalScore, currentPlayer.time, currentPlayer.levelCount, now, ImageToByteArray(currentPlayer.image));

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


        #region image to bytearray

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion



        // adds a value to currentPlayers score
        public void AddScore(int score)
        {
            currentPlayer.AddScore(score);
        }

        // returns currentPlayers score
        public string UpdateScore()
        {
            return currentPlayer.UpdateScore();
        }

        // gets current players time
        public void GetTime(int time)
        {
            currentPlayer.SaveTime(time);
        }

        // subtracts a life from currentPlayers health
        public void LoseHealth(int hit)
        {
            currentPlayer.LoseLife(hit);
        }

        // Returns currentPlayer's current health
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

        //gets all highscore entries
        public void LoadHighscore()
        {
            try
            {
                dbcontroller.GetAllEntries();
                highscore.Sort();
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

        // removes an entry from the highscores
        public void RemoveEntry(int entryID)
        {
            try
            {
                if (entryID != -1)
                {
                    dbcontroller.DeleteEntry(entryID);
                    highscore.RemoveEntry(entryID);
                }
                else
                {
                    throw new Exception("Pladsen er tom");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Deletes all entrys from highscores
        public void ResetHighscore()
        {
            try
            {
                dbcontroller.ResetHighscore();
                highscore.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Deletes all entries that are not in top 10 and not from today
        public void DailyClear()
        {
            try
            {
                dbcontroller.DailyClear();
                highscore.Clear();
                LoadHighscore();                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //removes all entries in daily highscore
        public void ResetDailyHighscore()
        {
            try
            {
                dbcontroller.ResetDailyHighscore();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //returns the current players data to gui
        public IPlayerData GetCurrentPlayer()
        {
            return (IPlayerData)currentPlayer;
        }
    }
}
