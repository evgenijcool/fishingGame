using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Classes.Stats
{
    interface IStatable
    {
        void addFish(Fish fish);
        int getSum();
    }
}
