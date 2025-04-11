using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    internal class SelectOperation_class
    {
        bool CanBuy(char user)
        {
            bool yesbuy = false;
            if (user == 'c')
                yesbuy = true;
            return yesbuy;
        }

        bool CanSupply(char user)
        {
            bool yessupply = false;
            if (user == 's')
                yessupply = true;
            return yessupply;
        }
    }
}
