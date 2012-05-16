using System;
using System.Drawing;
namespace Interface
{
    public interface IEntry
    {
        int entryID { get; set; }
        DateTime entryTime { get; set; }
        System.Drawing.Image image { get; set; }
        int levelCount { get; set; }
        int playTime { get; set; }
        int score { get; set; }
    }
}
