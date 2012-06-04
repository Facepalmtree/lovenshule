using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Interface;

namespace Model
{
    public class PlayerData : Interface.IPlayerData
    {
        //Declaring class variables
        public int totalScore { get; set; }
        public Image image { get; set; }
        public int time { get; set; }
        public int levelCount { get; set; }
        public int health { get; set; }
        public Level level { get; set; }
        

        public PlayerData(Image image)

        {
            this.totalScore = 0;
            this.image = image;
            this.time = 0;            
            this.levelCount = 1;
            this.health = 10;
            
            //create a level which will be used to keep track of the game's difficulty.
            level = new Level(1);
        }

        public int GetCoordinateSize()
        {
            return level.GetCoordinateSize();
        }

        public int GetXCoordinates(int ID)
        {
            return level.GetXCoordinates(ID);
        }

        public int GetYCoordinates(int ID)
        {
            return level.GetYCoordinates(ID);
        }

        public int GetChanceNormal()
        {
            return level.GetChanceNormal();
        }

        public int GetChanceBomb()
        {
            return level.GetChanceBomb();
        }

        public int GetChanceStrong()
        {
            return level.GetChanceStrong();
        }

        public int GetChanceFat()
        {
            return level.GetChanceFat();
        }

        public bool SpawnDecrease()
        {
            return level.SpawnDecrease();
        }

        public int GetHoleCount()
        {
            return level.holesCount;
        }

        public decimal GetSpawnFrequency()
        {
            return level.spawnFrequency;
        }

        public void Nextlevel()
        {
            levelCount += 1;
            level.nextLevel(levelCount);
        }

        //temp without image
        public PlayerData()
        {
            this.totalScore = 0;
            this.time = 0;            
            this.levelCount = 1;
            this.health = 10;
            this.image = null;
        }

        //Adds points to score
        public void AddScore(int score) 
        {
            totalScore += score;
        }

        //Substracts points to score
        public void SubstractScore(int score)
        {
            totalScore -= score;
        }

        //Gets current score
        public string UpdateScore()
        {
            return Convert.ToString(totalScore);
        }

        //Gets time played
        public void SaveTime(int time)
        {
            time = this.time;
        }

        //Subtracts a lifepoint
        public void LoseLife(int hit)
        {
            health -= hit;
        }

        //Gets current lifepoints
        public string UpdateHealth()
        {
            return Convert.ToString(health);
        }

        //Saves user picture
        public void SetImage(Image image)
        {
            image = this.image;
        }
    }
}
