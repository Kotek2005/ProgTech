using System.Collections.Generic;

namespace LogicLayer
{
    public interface ILogicService
    {
        void AddProduct(string name, float price);
        Dictionary<string, float> GetAllProducts();

        void AddSupply(string productName, int quantity);
 
        bool BuyProduct(string productName, int quantity);
        
        void AddUser(int userId, string userType);
        Dictionary<int, string> GetAllUsers();

        void AddToState(string productName, int amount);
        Dictionary<string, int> GetAllInventory();
        float GetCurrentCash();
    }
} 