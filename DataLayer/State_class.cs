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
        Dictionary<string, int> inventory;
        float cash;

        void Add2State(string name, int amount)
        {
            inventory.Add(name, amount);
        }

        float GetCash() { return cash; }
    }
}
