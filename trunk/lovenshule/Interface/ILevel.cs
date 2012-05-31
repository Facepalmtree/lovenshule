using System;
namespace Interface
{
    public interface ILevel
    {
        System.Drawing.Image background { get; set; }
        System.Collections.Generic.List<int> GetXCoordinates();
        System.Collections.Generic.List<int> GetYCoordinates();
        int holesCount { get; set; }
        void nextLevel(int level);
        void ResetLevel();
        int spawn { get; set; }
        int spawnCount { get; set; }
        bool SpawnDecrease();
        decimal spawnFrequency { get; set; }
        int startTime { get; set; }
        int theme { get; set; }
    }
}
