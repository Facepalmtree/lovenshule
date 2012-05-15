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
        

        public PlayerData( int totalScore, string picture, int time, int levelCount, int health, Image image)
        {
            this.totalScore = totalScore;
            this.image = image;
            this.time = time;            
            this.levelCount = levelCount;
            this.health = health;
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

        public 
    }
}
