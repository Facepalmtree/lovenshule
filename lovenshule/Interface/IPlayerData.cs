using System;
namespace Model
{
    public interface IPlayerData
    {
        void AddScore(int score);
        void LoseLife(int hit);
        void SaveTime(int time);
        void SetImage(System.Drawing.Image image);
        void SetLevel(int level);
        string UpdateHealth();
        string UpdateScore();
    }
}
