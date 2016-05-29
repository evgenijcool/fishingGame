using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Assets.Classes.Stats
{
    class ProxyStatistics : IStatable
    {
        static ProxyStatistics proxy;
        private Statistics stts = null;
        private object sum;
        private string filename = "proxystats";

        private ProxyStatistics()
        {
            Load();
            if (sum == null)
                sum = 0;
        }

        public static IStatable instance()
        {
            if (proxy == null)
                proxy = new ProxyStatistics();
            return proxy;
        }

        public void addFish(Fish fish)
        {
            if (stts == null)
                stts = new Statistics();
            stts.addFish(fish);
            sum = stts.getSum();
            Save();
        }

        public int getSum()
        {
            if (stts != null)
                return stts.getSum();
            else
                return (int) sum;
        }

        private void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, sum);
            }
        }

        private void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    sum = null;
                else
                    sum = formatter.Deserialize(fs) as object;
            }
        }
    }
}
