using System;

namespace Classes.FishFactories
{
    class GoodFishFactory : IFishFactory
    {
        static Random rnd = new Random();
        public Fish generateFish()
        {
            Fish gFish = new Fish();
            gFish.Money = rnd.Next(1, 12) * 100;
            gFish.Speed = rnd.Next(80, 250) / 10.0F;
            gFish.SpriteNumber = rnd.Next(0, 5);
            return gFish;
        }
    }
}