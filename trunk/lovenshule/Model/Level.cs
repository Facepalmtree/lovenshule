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
        public int startTime { get; set; }
        public int spawn { get; set; }
        public int spawnCount { get; set; }
        public int theme { get; set; }

        public Level(string background, decimal spawnFrequency, List<Hole> holes, int startTime, int spawn, int spawnCount, int theme)
        {
            this.background = background;
            this.spawnFrequency = spawnFrequency;
            this.holes = holes;
            this.startTime = startTime;
            this.spawn = spawn;
            this.spawnCount = spawnCount;
            this.theme = theme;
        }
    }
}
