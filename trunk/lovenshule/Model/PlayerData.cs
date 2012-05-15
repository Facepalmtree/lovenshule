using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PlayerData
    {
        //Declaring class variables
        public int totalScore { get; set; }
        //public string picture { get; set; }
        public int time { get; set; }
        public int levelCount { get; set; }
        public int health { get; set; }
        

        public PlayerData( int totalScore, string picture, int time, int levelCount, int health)
        {
            this.totalScore = totalScore;
            //this.picture = picture;
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
    }
}
