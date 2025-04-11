using System.Diagnostics;

namespace DataLayer
{
    internal class Users_class
    {
        private Dictionary<int, string> users;

        public void Add2Users(int ID, string type)
        {
            users.Add(ID, type);
        }

        public string FindUser(int id)
        {
            return users[id];
        }
    }
}
