using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Hole
    {
        Unit currentUnit;
        
        //Get these values however you like.
        static DateTime timeEnd = DateTime.Parse("20/5/2012 12:00:01 AM");
        static DateTime timeStart = DateTime.Now;

        //Calculate countdown timer.
        static TimeSpan t = timeEnd - timeStart;
        string countDown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", t.Days, t.Hours, t.Minutes, t.Seconds);


        public Hole()
        {
            this.currentUnit = null;
        }

        public void SpawnUnit(int type)
        {
            switch (type)
            {
                //NORMAL
                case 1:
                    currentUnit = new UnitNormal(this);

                    break;
                //AVOID
                case 2:
                    currentUnit = new UnitAvoid(this);
                    break;
                //STRONG
                case 3:
                    currentUnit = new UnitStrong(this);
                    break;
                //FAT
                case 4:
                    currentUnit = new UnitFat(this);
                    break;
                //STAR
                case 5:
                    currentUnit = new UnitStar(this);
                    break;
                //RED
                case 6:
                    currentUnit = new UnitRed(this);
                    break;
                //GREEN
                case 7:
                    currentUnit = new UnitGreen(this);
                    break;
                //BLUE
                case 8:
                    currentUnit = new UnitBlue(this);
                    break;
                //YELLOW
                case 9:
                    currentUnit = new UnitYellow(this);
                    break;
                default:
                    break;
            }
        }

        public void Attack()
        {

        }
    }
}
