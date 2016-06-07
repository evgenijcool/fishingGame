using System;
using UnityEngine;

namespace Classes.FishFactories
{
    class GoodFishFactory : IFishFactory
    {
        static System.Random rnd = new System.Random();
        public Fish generateFish()
        {
            Fish gFish = new Fish();
            gFish.Money = rnd.Next(1, 12) * 100;
            gFish.Speed = rnd.Next(50, 200) / 10.0F;
            gFish.SpriteNumber = rnd.Next(0, 5);
            return gFish;
        }
    }
}