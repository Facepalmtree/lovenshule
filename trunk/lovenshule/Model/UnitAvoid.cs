using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitAvoid : Unit
    {
        public UnitAvoid()
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 500;
            this.Lives = 1;
            this.Damage = 2;
            this.SpawnTime = 30*2;
        }
    }
}
