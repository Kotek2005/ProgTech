using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;

namespace LogicLayer
{
    internal class Buy_class
    {
        private readonly IEvents Events;

        public Buy_class(IEvents events)
        {
            Events = events;
        }

        bool Buy(string product, int amount)
        {
            bool isinstock = Events.CheckStock(product, amount);
            if (!isinstock)
                return false;
            float sum = Events.GetPrice(product) * amount;
            Events.AddStock(product, (-1) * amount);
            Events.AddMoney(sum);
            return true;
        }
    }
}
