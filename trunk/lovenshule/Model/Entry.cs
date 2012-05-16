using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

using Interface;

namespace Model
{
    public class Entry : Interface.IEntry
    {
        //Declaring class variables
        public int score { get; set; }        
        public int playTime { get; set; }
        public int levelCount { get; set; }
        public int entryID { get; set; }
        public DateTime entryTime { get; set; }
        public Image image { get; set; }

        public Entry(int score, int playTime, int levelCount, int entryID, DateTime entryTime, Image image)
        {
            this.score = score;
            this.playTime = playTime;
            this.levelCount = levelCount;
            this.entryID = entryID;
            this.entryTime = entryTime;
            this.image = image;
        }
    }
}
