using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;

namespace LogicLayer
{
    internal class Supply_class
    {
        private readonly IEvents Events;

        public Supply_class(IEvents events)
        {
            Events = events;
        }

        bool Supply(string product, int amount)
        {
            float surprise = Events.GetPrice(product) * amount * (1 / 3); //hehe cuz sup-price
            surprise = (float)Math.Round(surprise, 2);
            bool havemoney = Events.CheckMoney(surprise);
            if (!havemoney)
                return false;
            Events.AddStock(product, amount);
            Events.AddMoney((-1) * surprise);
            return true;
        }
    }
}
