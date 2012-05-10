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
        public int points { get; set; }
        public Hole currentHole { get; set; }
        public int frame { get; set; }
        public int maxFrame { get; set; }
        public int damage { get; set; }
        public int spawnTime { get; set; }

        public PlayerData( int score, string picture, int points, Hole currentHole, int frame, int maxFrame, int damage, int spawnTime )
        {
            this.score = score;
            this.picture = picture;
            this.points = points;
            this.currentHole = currentHole;
            this.frame = frame;
            this.maxFrame = maxFrame;
            this.damage = damage;
            this.spawnTime = spawnTime;
        }
    }
}
