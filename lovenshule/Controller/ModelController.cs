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
        List<Unit> bonusUnits = new List<Unit>();
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


        //Functions to access attributes from the level class.
        public bool SpawnDecrease()
        {
            return currentPlayer.SpawnDecrease();
        }

        //Returns the amount of holes, this level should have.
        public int GetHoleCount()
        {
            return currentPlayer.GetHoleCount();
        }

        //return the spawn frequency this level should use.
        public decimal GetSpawnFrequency()
        {
            return currentPlayer.GetSpawnFrequency();
        }

        //Go to the next level.
        public void Nextlevel()
        {
            currentPlayer.Nextlevel();
        }

        //Return a possible x coordinate.
        public int GetXCoordinates(int ID)
        {
            return currentPlayer.GetXCoordinates(ID);
        }

        //return a possible y coordinate.
        public int GetYCoordinates(int ID)
        {
            return currentPlayer.GetYCoordinates(ID);
        }

        //Return how many different coordinate positions there are.
        public int GetCoordinatesSize()
        {
            return currentPlayer.GetCoordinateSize();
        }


        // if the units' spawntime is not 0, its subtracts 1 from the spawntime and returns false
        // if it is 0 or less it returns true
        public IUnit getUnit(int ID)
        {
            return (IUnit)units[ID];
        }

        //Return a bonus unit, so we can read it's attributes.
        public IUnit getBonusUnit(int ID)
        {
            return (IUnit)bonusUnits[ID];
        }

        //Reduce the health of a mole, return true if it dies, and false if not.
        public bool reduceHealth(int ID)
        {
            units[ID].Lives -= 1;
            if (units[ID].Lives <= 0) return true;
            else return false;
        }


        //Reduce the health of a bonusmole, return true if it dies, and false if not.
        public bool reduceHealthBonus(int ID)
        {
            bonusUnits[ID].Lives -= 1;
            if (bonusUnits[ID].Lives <= 0) return true;
            else return false;
        }

        //Updates the spawntimer of a mole, return true if spawnTime has ended.
        public bool UpdateSpawnTime(int ID)
        {
            if (units[ID].SpawnTime!=0)
            units[ID].SpawnTime -= 1;
            if (units[ID].SpawnTime <= 0) return true; else return false;
        }


        //Updates the spawntimer of a bonusmole, return true if spawnTime has ended.
        public bool UpdateBonusSpawnTime(int ID)
        {
            if (bonusUnits[ID].SpawnTime != 0)
                bonusUnits[ID].SpawnTime -= 1;
            if (bonusUnits[ID].SpawnTime <= 0) return true; else return false;
        }

        // Gives a value to a units spawntime
        public void SetSpawnTime(int ID, int time)
        {
            units[ID].SpawnTime = time;
        }

        // Gives a value to a units spawntime
        public void SetBonusSpawnTime(int ID, int time)
        {
            bonusUnits[ID].SpawnTime = time;
        }

        //Spawn a new unit.
        public void NewUnit(int Type)
        {
            //Creates a new mole.
            switch(Type)
            {
                case 1:
                    units.Add(new UnitNormal());
                break;

                case 2:
                    units.Add(new UnitAvoid());
                break;

                case 3:
                    units.Add(new UnitStrong());
                break;

                case 4:
                    units.Add(new UnitFat());
                    break;

                case 5:
                    bonusUnits.Add(new UnitBonus());
                break;
            }
        }

        public int GetUnitCount()
        {
            //Returns the size of the unit list.
            return units.Count;
        }

        public int GetBonusUnitCount()
        {
            //Returns the size of the unit list.
            return bonusUnits.Count;
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
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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

        // substracts a value to currentPlayers score
        public void SubstractScore(int score)
        {
            currentPlayer.SubstractScore(score);
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
                highscore.Clear();
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
        /*we're aware that we're reloading the entire highscorelist, but as the calculations are done serverside
        this was the easiest way (considering we're dealing with a fixed number of entries)*/
        public void ResetDailyHighscore()
        {
            try
            {
                dbcontroller.ResetDailyHighscore();
                highscore.Clear();
                LoadHighscore();
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
