using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class UnitFat : Unit
    {
        public UnitFat(Hole currentHole)
            : base(currentHole)
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 2300;
            this.Lives = 10;
            this.Damage = 5;
            this.SpawnTime = 10;
        }
    }
}
