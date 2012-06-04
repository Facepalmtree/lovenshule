using System;
namespace Interface
{
    public interface ILevel
    {
        System.Drawing.Image background { get; set; }
        int holesCount { get; set; }
        void nextLevel(int level);
        void ResetLevel();
        int GetXCoordinates(int ID);
        int GetYCoordinates(int ID);
        int GetCoordinateSize();
        int spawn { get; set; }
        int spawnCount { get; set; }
        bool SpawnDecrease();
        decimal spawnFrequency { get; set; }
        int startTime { get; set; }
        int theme { get; set; }
    }
}
