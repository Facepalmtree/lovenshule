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
        Hole currentHole;
        int frame;
        int maxFrame;
        int damage;
        int spawnTime;

        public Unit(Hole currentHole)
        {
            this.currentHole = currentHole;
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
        internal Hole CurrentHole
        {
            get { return currentHole; }
            set { currentHole = value; }
        }
        public int Frame
        {
            get { return frame; }
            set { frame = value; }
        }
        public int MaxFrame
        {
            get { return maxFrame; }
            set { maxFrame = value; }
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
