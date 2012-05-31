using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Model
{
    public class Level : Model.ILevel
    {
        public Image background { get; set; }
        public decimal spawnFrequency { get; set; }
        public List<Hole> holes { get; set; }
        public int holesCount { get; set; }
        public int startTime { get; set; }
        public int spawn { get; set; }
        public int spawnCount { get; set; }
        public int theme { get; set; }
        List<int> holeXCoordinates = new List<int>();
        List<int> holeYCoordinates = new List<int>();

        public Level(int level)
        {
            startTime = holesCount = spawn = 0;
            holes = new List<Hole>();


            holeXCoordinates.Add(83);
            holeXCoordinates.Add(83);
            holeXCoordinates.Add(283);
            holeXCoordinates.Add(283);
            holeXCoordinates.Add(483);
            holeXCoordinates.Add(483);
            holeXCoordinates.Add(683);
            holeXCoordinates.Add(683);
            holeXCoordinates.Add(883);
            holeXCoordinates.Add(883);
            holeXCoordinates.Add(1083);
            holeXCoordinates.Add(1083);

            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);
            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);
            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);
            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);
            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);
            holeYCoordinates.Add(284);
            holeYCoordinates.Add(484);

            nextLevel(level);
        }

        public List<int> GetXCoordinates()
        {
            return holeXCoordinates;
        }

        public List<int> GetYCoordinates()
        {
            return holeYCoordinates;
        }

        //holds data for each level
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
                    spawnFrequency = 4;

                    break;
                case 3: 
                    holesCount = 5;
                    spawn = 30;
                    spawnFrequency = 5;

                    break;
                case 4:
                    holesCount = 5;
                    spawn = 40;
                    spawnFrequency = 6;

                    break;
                case 5:
                    holesCount = 7;
                    spawn = 50;
                    spawnFrequency = 7;

                    break;
                case 6:
                    holesCount = 7;
                    spawn = 60;
                    spawnFrequency = 8;

                    break;
                case 7:
                    holesCount = 9;
                    spawn = 70;
                    spawnFrequency = 9;

                    break;
                case 8:
                    holesCount = 9;
                    spawn = 80;
                    spawnFrequency = 10;

                    break;
                case 9:
                    holesCount = 9;
                    spawn = 90;
                    spawnFrequency = 11;

                    break;
                case 10:
                    holesCount = 9;
                    spawn = 100;
                    spawnFrequency = 12;

                    break;
                default:
                    break;
            }
            spawnCount = spawn;
        }
        
        //Gets current number of moles spawned
        public bool SpawnDecrease()
        {
            spawnCount -= 1;
            //returns true, if the game should go to next level, returns false, otherwise.
            if (spawnCount <= 0)
                return true;
            else
                return false;
        }

        //starts the level overs
        public void ResetLevel()
        {
            startTime = holesCount = spawn = 0;
            holes = new List<Hole>();
        }
    }
}
