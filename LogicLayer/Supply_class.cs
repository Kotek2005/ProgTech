using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;

namespace LogicLayer
{
    public class Supply_class
    {
        private readonly IEvents Events;

        public Supply_class(IEvents events)
        {
            Events = events;
        }

        public bool Supply(string product, int amount)
        {
            float surprise = Events.GetPrice(product) * amount * (float)0.3; //hehe cuz sup-price
            surprise = (float)Math.Round(surprise, 2);
            Console.WriteLine(surprise);
            bool havemoney = Events.CheckMoney(surprise);
            if (!havemoney)
                return false;
            Events.AddStock(product, amount);
            Events.AddMoney((-1) * surprise);
            return true;
        }
    }
}
