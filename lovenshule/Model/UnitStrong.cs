using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitStrong : Unit
    {
        public UnitStrong()
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 300;
            this.Lives = 1;
            this.Damage = 2;
            this.SpawnTime = 2;
        }
    }
}
