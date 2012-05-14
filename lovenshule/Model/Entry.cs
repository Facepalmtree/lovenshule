using System;
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
        public int time { get; set; }
        public int levelCount { get; set; }
        public int entryID { get; set; }

        public Entry(int scor, int tim, int levelC, int entry)
        {
            score = scor;
            time = tim;
            levelCount = levelC;
            entryID = entry;
        }
    }
}
