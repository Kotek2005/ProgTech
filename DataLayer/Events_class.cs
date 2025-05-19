using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IEvents
    {
        string FindUser(int id);
        float GetPrice(string product);
        bool CheckStock(string product, int amount);
        bool CheckMoney(float price);
        void AddStock(string product, int amount);
        void AddMoney(float amount);
        void Add2Cat(string product, float price);
        void Add2Users(int id, string name);
        void Add2State(string product, int amount);
        Dictionary<int, string> GetAllUsers();
        Dictionary<string, float> GetAllProducts();
        Dictionary<string, int> GetAllInventory();
        float GetCurrentCash();
    }

    public class Events_class : IEvents
    {
        private readonly ShopDataBaseDataContext _db;

        public Events_class()
        {
            _db = new ShopDataBaseDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopDatabase.mdf;Integrated Security=True");
        }

        public string FindUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user?.Type;
        }

        public bool CheckStock(string product, int amount)
        {
            var state = _db.States.FirstOrDefault(s => s.Product == product);
            return state != null && state.Amount >= amount;
        }

        public bool CheckMoney(float price)
        {
            // For now, we'll assume there's always enough money
            return true;
        }

        public float GetPrice(string product)
        {
            var catalog = _db.Catalogs.FirstOrDefault(c => c.Product == product);
            return catalog?.Price != null ? (float)catalog.Price : 0;
        }

        public void AddMoney(float profit)
        {
            // This would need to be implemented if we add a Cash table
        }

        public void AddStock(string product, int amount)
        {
            var state = _db.States.FirstOrDefault(s => s.Product == product);
            if (state != null)
            {
                state.Amount += amount;
            }
            else
            {
                _db.States.InsertOnSubmit(new State { Product = product, Amount = amount });
            }
            _db.SubmitChanges();
        }

        public void Add2Cat(string product, float price)
        {
            var catalog = _db.Catalogs.FirstOrDefault(c => c.Product == product);
            if (catalog != null)
            {
                catalog.Price = price;
            }
            else
            {
                _db.Catalogs.InsertOnSubmit(new Catalog { Product = product, Price = price });
            }
            _db.SubmitChanges();
        }

        public void Add2Users(int id, string type)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Type = type;
            }
            else
            {
                _db.Users.InsertOnSubmit(new User { Id = id, Type = type });
            }
            _db.SubmitChanges();
        }

        public void Add2State(string product, int amount)
        {
            var state = _db.States.FirstOrDefault(s => s.Product == product);
            if (state != null)
            {
                state.Amount = amount;
            }
            else
            {
                _db.States.InsertOnSubmit(new State { Product = product, Amount = amount });
            }
            _db.SubmitChanges();
        }

        public Dictionary<int, string> GetAllUsers()
        {
            return _db.Users.ToDictionary(u => u.Id, u => u.Type);
        }

        public Dictionary<string, float> GetAllProducts()
        {
            return _db.Catalogs.ToDictionary(c => c.Product, c => (float)c.Price);
        }

        public Dictionary<string, int> GetAllInventory()
        {
            return _db.States.ToDictionary(s => s.Product, s => s.Amount ?? 0);
        }

        public float GetCurrentCash()
        {
            // For now, return a fixed amount since we don't have a Cash table
            return 1000.0f;
        }
    }
}
