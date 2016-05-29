
using Classes;
using System.Collections.Generic;

namespace Assets.Classes
{
    class Statistics
    {
        static private List<Fish> fishes = new List<Fish>();

        static public void addFish(Fish fish)
        {
            fishes.Add(fish);
        }
        static public string getSum()
        {
            int sum = 0;
            fishes.ForEach(fish => sum += fish.Money);
            return sum + "$";
        }
    }
}
