using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class DataRepository : IDataRepository
    {
        private readonly ShopDataBaseDataContext _db;

        public DataRepository(string connectionString)
        {
            _db = new ShopDataBaseDataContext(connectionString);
        }

        public void AddUser(int id, string type)
        {
            var user = new User { Id = id, Type = type };
            _db.Users.InsertOnSubmit(user);
            _db.SubmitChanges();
        }

        public User GetUser(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users;
        }

        public void RemoveUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _db.Users.DeleteOnSubmit(user);
                _db.SubmitChanges();
            }
        }

        public void AddCatalog(string product, float price)
        {
            var catalog = new Catalog { Product = product, Price = price };
            _db.Catalogs.InsertOnSubmit(catalog);
            _db.SubmitChanges();
        }

        //LINQ method syntax
        public Catalog GetCatalog(string product)
        {
            return _db.Catalogs.FirstOrDefault(c => c.Product == product);
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return _db.Catalogs;
        }

        public void RemoveCatalog(string product)
        {
            var catalog = _db.Catalogs.FirstOrDefault(c => c.Product == product);
            if (catalog != null)
            {
                _db.Catalogs.DeleteOnSubmit(catalog);
                _db.SubmitChanges();
            }
        }

        public void AddState(string product, int amount)
        {
            var state = new State { Product = product, Amount = amount };
            _db.States.InsertOnSubmit(state);
            _db.SubmitChanges();
        }

        public State GetState(string product)
        {
            return _db.States.FirstOrDefault(s => s.Product == product);
        }

        public IEnumerable<State> GetAllStates()
        {
            return _db.States;
        }

        public void RemoveState(string product)
        {
            var state = _db.States.FirstOrDefault(s => s.Product == product);
            if (state != null)
            {
                _db.States.DeleteOnSubmit(state);
                _db.SubmitChanges();
            }
        }

        public void UpdateState(string product, int newAmount)
        {
            var state = _db.States.FirstOrDefault(s => s.Product == product);
            if (state != null)
            {
                state.Amount = newAmount;
                _db.SubmitChanges();
            }
        }

        public void ClearAll()
        {
            _db.Users.DeleteAllOnSubmit(_db.Users);
            _db.Catalogs.DeleteAllOnSubmit(_db.Catalogs);
            _db.States.DeleteAllOnSubmit(_db.States);
            _db.SubmitChanges();
        }

        public static IDataRepository CreateNewRepository(string connectionString)
        {
            return new DataRepository(connectionString);
        }
    }
} 