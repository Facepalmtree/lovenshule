﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class UnitBlue : Unit
    {
        public UnitBlue(Hole currentHole)
            : base(currentHole)
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 1000;
            this.Lives = 1;
            this.Damage = 1;
            this.SpawnTime = 1;
        }
    }
}
