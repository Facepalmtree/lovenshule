using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;

namespace Model
{
    public abstract class Unit : Interface.IUnit
    {
        int lives;
        int point;
        int damage;
        int spawnTime;

        public Unit()
        {
        }

        #region Methods

        #endregion

        #region Properties

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int SpawnTime
        {
            get { return spawnTime; }
            set { spawnTime = value; }
        }
        #endregion

    }
}
