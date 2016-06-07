using System;
using UnityEngine;

namespace Classes.FishFactories
{
    class AngryFishFactory : IFishFactory
    {
        static System.Random rnd = new System.Random();
        public Fish generateFish()
        {
            Fish aFish = new Fish();
            aFish.Money = -1 * rnd.Next(1, 9) * 100;
            aFish.Speed = rnd.Next(250, 350) / 10.0F;
            aFish.SpriteNumber = rnd.Next(0, 2);
            return aFish;
        }
    }
}
