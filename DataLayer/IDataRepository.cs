using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataRepository
    {
        void AddUser(int id, string type);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void RemoveUser(int id);

        void AddCatalog(string product, float price);
        Catalog GetCatalog(string product);
        IEnumerable<Catalog> GetAllCatalogs();
        void RemoveCatalog(string product);

        void AddState(string product, int amount);
        State GetState(string product);
        IEnumerable<State> GetAllStates();
        void RemoveState(string product);
        void UpdateState(string product, int newAmount);

        //database stuff
        void ClearAll();
        static IDataRepository CreateNewRepository(string connectionString) => throw new NotImplementedException();
    }
} 