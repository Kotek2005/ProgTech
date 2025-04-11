using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class Events_class
    {
        string FindUser(int id)
        {
            return Users_class.users[id];
        }

        bool CheckStock(string product, int amount)
        {
            int wegot = State_class.inventory[product];
            if (amount <= wegot)
                return true;
            else
                return false;
        }

        bool CheckMoney(float price)
        {
            float money = State_class.GetCash();
            if (price <= money)
                return true;
            else
                return false;
        }

        float GetPrice(string product)
        {
            return Catalog_class.prices[product];
        }

        void AddMoney(float profit)
        {
            State_class.cash += profit;
        }

        void AddStock(string product, int amount)
        {
            State_class.inventory[product] += amount;
        }
    }
}
