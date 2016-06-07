using Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    [Serializable]
    abstract class Fish
    {
        public float Speed { get; set; }
        public int Money { get; set; }
        public int SpriteNumber { get; set; }

        public void updateStats()
        {
            StatChanger.inctance().updateStats(this);
        }
    }
}
