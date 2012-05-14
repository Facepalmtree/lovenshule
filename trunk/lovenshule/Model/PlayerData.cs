using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PlayerData
    {
        public int score { get; set; }
        public string picture { get; set; }
        public int time { get; set; }
        public int levelCount { get; set; }

        public PlayerData( int score, string picture, int time, int levelCount)
        {
            this.score = score;
            this.picture = picture;
            this.time = time;            
            this.levelCount = levelCount;
        }
    }
}
