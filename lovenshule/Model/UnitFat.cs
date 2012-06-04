using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitFat : Unit
    {
        public UnitFat()
        {
            //revise this!!!!!!!!!!!!!!!!
            //this.Frame =
            //this.MaxFrame =
            this.Point = 2500;
            this.Lives = 10;
            this.Damage = 50;
            this.SpawnTime = 30*10;
        }
    }
}
