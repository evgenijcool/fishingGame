using Assets.Classes.Stats;
using Classes;

namespace Assets.Classes
{
    class StatChanger
    {
        static private StatChanger sch = null;
        private StatChanger() {}
        static public StatChanger inctance()
        {
            if (sch == null)
                sch = new StatChanger();
            return sch;
        }
        public void updateStats(Fish fish)
        {
            ProxyStatistics.instance().addFish(fish);
        }
    }
}
