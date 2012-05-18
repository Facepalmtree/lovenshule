using System;
namespace Interface
{
    public interface IPlayerData
    {
        void AddScore(int score);
        int health { get; set; }
        System.Drawing.Image image { get; set; }
        int levelCount { get; set; }
        void LoseLife(int hit);
        void SaveTime(int time);
        void SetImage(System.Drawing.Image image);
        void SetLevel(int level);
        int time { get; set; }
        int totalScore { get; set; }
        string UpdateHealth();
        string UpdateScore();
    }
}
