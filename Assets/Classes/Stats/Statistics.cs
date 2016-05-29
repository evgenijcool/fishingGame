
using Assets.Classes.Stats;
using Classes;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Classes
{
    class Statistics : IStatable
    {
        private string filename = "stats";

        private List<Fish> fishes;

        public Statistics()
        {
            Load();
            if (fishes == null)
                fishes = new List<Fish>();
        }

        public void addFish(Fish fish)
        {
            fishes.Add(fish);

            Save();
        }

        public int getSum()
        {
            int sum = 0;
            fishes.ForEach(fish => sum += fish.Money);
            return sum;
        }

        private void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, fishes);
            }
        }

        private void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    fishes = null;
                else
                    fishes = formatter.Deserialize(fs) as List<Fish>;
            }
        }
    }
}
