using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Level
    {
        public string background { get; set; }
        public decimal spawnFrequency { get; set; }
        public List<Hole> holes { get; set; }
        public int holesCount { get; set; }
        public int startTime { get; set; }
        public int spawn { get; set; }
        public int spawnCount { get; set; }
        public int theme { get; set; }

        public Level()
        {
            startTime = holesCount = spawn = 0;
            holes = new List<Hole>();

        }

        public void nextLevel(int level)
        {           
            switch (level)
            {
                case 1: 
                    holesCount = 3;
                    spawn = 10;
                    spawnFrequency = 3;

                    break;
                case 2:
                    holesCount = 3;
                    spawn = 20;
                    break;
                case 3: 
                    holesCount = 5;
                    spawn = 30;
                    break;
                case 4:
                    holesCount = 5;
                    spawn = 40;
                    break;
                case 5:
                    holesCount = 7;
                    spawn = 50;
                    break;
                case 6:
                    holesCount = 7;
                    spawn = 60;
                    break;
                case 7:
                    holesCount = 9;
                    spawn = 70;
                    break;
                case 8:
                    holesCount = 9;
                    spawn = 80;
                    break;
                case 9:
                    holesCount = 9;
                    spawn = 90;
                    break;
                case 10:
                    holesCount = 9;
                    spawn = 100;
                    break;
                default:
                    break;
            }       
        }
        
        public void SpawnCount()
            {
                if (spawnCount < spawn)
                {
                    spawnCount += 1;
                }
                else
                {
                    nextLevel();
                }
            }

        public void ResetLevel()
        {
            startTime = holesCount = spawn = 0;
            holes = new List<Hole>();
        }
    }
}
