using System;

namespace Classes.FishFactories
{
    class AngryFishFactory : IFishFactory
    {
        static Random rnd = new Random();
        public Fish generateFish()
        {
            Fish aFish = new Fish();
            aFish.Money = -1 * rnd.Next(1, 9) * 100;
            aFish.Speed = rnd.Next(100, 200) / 10.0F;
            aFish.SpriteNumber = rnd.Next(0, 2);
            return aFish;
        }
    }
}
