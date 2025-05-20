using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace LogicLayer
{
    public class LogicService : ILogicService
    {
        private readonly IEvents _events;
        private readonly Supply_class _supplyService;
        private readonly Buy_class _buyService;
        private readonly Login_class _loginService;

        public LogicService(IEvents events)
        {
            _events = events;
            _supplyService = new Supply_class(events);
            _buyService = new Buy_class(events);
            _loginService = new Login_class(events);
        }

        public void AddProduct(string name, float price)
        {
            _events.Add2Cat(name, price);
        }

        public Dictionary<string, float> GetAllProducts()
        {
            return _events.GetAllProducts()
                .Where(kvp => kvp.Key != null)
                .ToDictionary(kvp => kvp.Key!, kvp => kvp.Value);
        }

        public void AddSupply(string productName, int quantity)
        {
            _supplyService.Supply(productName, quantity);
        }

        /*public int GetProductQuantity(string productName)
        {
            var inventory = _events.GetAllInventory();
            return inventory.TryGetValue(productName, out int amount) ? amount : 0;
        }*/

        public bool BuyProduct(string productName, int quantity)
        {
            return _buyService.Buy(productName, quantity);
        }

        public void AddUser(int userId, string userType)
        {
            _events.Add2Users(userId, userType);
        }

        public Dictionary<int, string> GetAllUsers()
        {
            return _events.GetAllUsers()
                .Where(kvp => kvp.Key != null)
                .ToDictionary(kvp => kvp.Key!.Value, kvp => kvp.Value);
        }

        public void AddToState(string productName, int amount)
        {
            _events.Add2State(productName, amount);
        }

        public Dictionary<string, int> GetAllInventory()
        {
            return _events.GetAllInventory()
                .Where(kvp => kvp.Key != null)
                .ToDictionary(kvp => kvp.Key!, kvp => kvp.Value);
        }

        public float GetCurrentCash()
        {
            return _events.GetCurrentCash();
        }
    }
} 