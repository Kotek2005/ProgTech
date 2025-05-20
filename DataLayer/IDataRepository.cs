using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataRepository
    {
        // User operations
        void AddUser(int id, string type);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void RemoveUser(int id);

        // Catalog operations
        void AddCatalog(string product, float price);
        Catalog GetCatalog(string product);
        IEnumerable<Catalog> GetAllCatalogs();
        void RemoveCatalog(string product);

        // State operations
        void AddState(string product, int amount);
        State GetState(string product);
        IEnumerable<State> GetAllStates();
        void RemoveState(string product);
        void UpdateState(string product, int newAmount);

        // Database management
        void ClearAll();
        static IDataRepository CreateNewRepository(string connectionString) => throw new NotImplementedException();
    }
} 