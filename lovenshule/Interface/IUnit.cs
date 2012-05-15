﻿using System;
namespace Interface
{
    public interface IUnit
    {
        int Damage { get; set; }
        int Frame { get; set; }
        int Lives { get; set; }
        int MaxFrame { get; set; }
        int Point { get; set; }
        int SpawnTime { get; set; }
    }
}
