using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UnitBonus : Unit
    {
        public UnitBonus()
        {
            this.Point = 500;
            this.Lives = 1;
            this.Damage = 0;
            this.SpawnTime = 45;
        }
    }
}
