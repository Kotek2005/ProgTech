namespace LogicLayer
{
    public class Login_class
    {
        char Login(int id)
        {
            string usertype;
            char worker;
            usertype = Events_class.FindUser(id); // dependedn injection i think idk
            if (usertype == "Supplier")
                worker = 's';
            else
                worker = 'c';
            return worker;
        }
    }
}
