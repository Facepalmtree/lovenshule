﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Entry
    {
        //Declaring class variables
        public int score { get; set; }
        //private Img Picture {get; set;}
        public int playTime { get; set; }
        public int levelCount { get; set; }
        public int entryID { get; set; }
        public DateTime entryTime { get; set; }

        public Entry(int score, int playTime, int levelCount, int entryID, DateTime entryTime)
        {
            this.score = score;
            this.playTime = playTime;
            this.levelCount = levelCount;
            this.entryID = entryID;
            this.entryTime = entryTime;
        }
    }
}