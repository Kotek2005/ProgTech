using DataLayer;

namespace LogicLayer
{
    public class Login_class
    {
        private readonly IEvents Events;

        public Login_class(IEvents events)
        {
            Events = events;
        }
        char Login(int id)
        {
            string usertype;
            char worker;
            usertype = Events.FindUser(id); // dependedn injection i think idk
            if (usertype == "Supplier")
                worker = 's';
            else
                worker = 'c';
            return worker;
        }
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
