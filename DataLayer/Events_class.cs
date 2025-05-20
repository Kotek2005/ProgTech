using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        Dictionary<int?, string> GetAllUsers();
        Dictionary<string?, float> GetAllProducts();
        Dictionary<string?, int> GetAllInventory();
        float GetCurrentCash();
    }

    public class Events_class : IEvents
    {
        private readonly IDataRepository _repository;
        private float _cash = 1000.0f; // Initial cash amount

        public Events_class()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(baseDir, "DataShop.mdf");
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            _repository = DataRepository.CreateNewRepository(connectionString);
        }

        public string FindUser(int id)
        {
            var user = _repository.GetUser(id);
            return user?.Type;
        }

        public bool CheckStock(string product, int amount)
        {
            var state = _repository.GetState(product);
            return state != null && state.Amount >= amount;
        }

        public bool CheckMoney(float price)
        {
            return _cash >= price;
        }

        public float GetPrice(string product)
        {
            var catalog = _repository.GetCatalog(product);
            return catalog != null ? (float)catalog.Price : 0f;
        }

        public void AddMoney(float profit)
        {
            _cash += profit;
        }

        public void AddStock(string product, int amount)
        {
            var state = _repository.GetState(product);
            if (state != null)
            {
                _repository.UpdateState(product, (state.Amount ?? 0) + amount);
            }
            else
            {
                _repository.AddState(product, amount);
            }
        }

        public void Add2Cat(string product, float price)
        {
            var catalog = _repository.GetCatalog(product);
            if (catalog != null)
            {
                _repository.RemoveCatalog(product);
            }
            _repository.AddCatalog(product, price);
        }

        public void Add2Users(int id, string type)
        {
            var user = _repository.GetUser(id);
            if (user != null)
            {
                _repository.RemoveUser(id);
            }
            _repository.AddUser(id, type);
        }

        public void Add2State(string product, int amount)
        {
            var state = _repository.GetState(product);
            if (state != null)
            {
                _repository.UpdateState(product, amount);
            }
            else
            {
                _repository.AddState(product, amount);
            }
        }

        public Dictionary<int?, string> GetAllUsers()
        {
            return _repository.GetAllUsers()
                .ToDictionary(u => (int?)u.Id, u => u.Type);
        }

        public Dictionary<string?, float> GetAllProducts()
        {
            return _repository.GetAllCatalogs()
                .ToDictionary(c => c.Product, c => (float)c.Price);
        }

        public Dictionary<string?, int> GetAllInventory()
        {
            return _repository.GetAllStates()
                .ToDictionary(s => s.Product, s => s.Amount ?? 0);
        }

        public float GetCurrentCash()
        {
            return _cash;
        }
    }
}
