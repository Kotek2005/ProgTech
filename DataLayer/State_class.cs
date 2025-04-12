using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class State_class
    {
        private Dictionary<string, int> inventory = new();
        private float cash=0;

        public bool CheckStock(string product, int amount)
        {
            int wegot = inventory[product];
            if (amount <= wegot)
                return true;
            else
                return false;
        }
        public void Add2State(string name, int amount)
        {
            inventory.Add(name, amount);
        }

        public bool CheckMoney(float price)
        {
            float money = cash;
            if (price <= money)
                return true;
            else
                return false;
        }

        public void AddStock(string product, int amount)
        {
            inventory[product] += amount;
        }

        public void AddMoney(float profit)
        {
            cash += profit;
        }
    }
}
