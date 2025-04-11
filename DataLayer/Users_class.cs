using System.Diagnostics;

namespace DataLayer
{
    public class Users_class
    {
        Dictionary<int, string> users;

        void Add2Users(int ID, string type)
        {
            users.Add(ID, type);
        }
    }
}
