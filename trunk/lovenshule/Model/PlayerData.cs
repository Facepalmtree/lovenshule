using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Model
{
    public class PlayerData
    {
        //Declaring class variables
        public int totalScore { get; set; }
        public Image image  { get; set; }
        public int time { get; set; }
        public int levelCount { get; set; }
        public int health { get; set; }
        

        public PlayerData(Image image)
        {
            this.totalScore = 0;
            this.image = image;
            this.time = 0;            
            this.levelCount = 1;
            this.health = 10;
        }

        //temp without image
        public PlayerData()
        {
            this.totalScore = 0;
            this.image = image;
            this.time = 0;            
            this.levelCount = 1;
            this.health = 10;
            this.image = null;
        }

        public void AddScore(int score) 
        {
            totalScore += score;
        }

        public string UpdateScore()
        {
            return Convert.ToString(totalScore);
        }

        public void SaveTime(int time)
        {
            time = this.time;
        }

        public void LoseLife(int hit)
        {
            health -= hit;
        }

        public string UpdateHealth()
        {
            return Convert.ToString(health);
        }

        public void SetLevel(int level)
        { 
            levelCount = level;
        }

        public void SetImage(Image image)
        {
            image = this.image;
        }
    }
}
