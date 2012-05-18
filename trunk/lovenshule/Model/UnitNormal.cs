using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitNormal : Unit
    {
        public UnitNormal(Hole currentHole)
            : base(currentHole)
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 100;
            this.Lives = 1;
            this.Damage = 1;
            this.SpawnTime = 1;
        }
    }
}
