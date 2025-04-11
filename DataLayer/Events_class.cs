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
    }

    public class Events_class : IEvents
    {
        private Users_class users = new();
        private State_class state = new();
        private Catalog_class catalog = new();

        public string FindUser(int id)
        {
            return users.FindUser(id);
        }

        public bool CheckStock(string product, int amount)
        {
            return state.CheckStock(product, amount);
        }

        public bool CheckMoney(float price)
        {
            return state.CheckMoney(price);
        }

        public float GetPrice(string product)
        {
            return catalog.GetPrice(product);
        }

        public void AddMoney(float profit)
        {
            state.AddMoney(profit);
        }

        public void AddStock(string product, int amount)
        {
            state.AddStock(product, amount);
        }


        public void Add2Cat(string product, float price) 
        { 
            catalog.Add2Cat(product, price);
        }

        public void Add2Users(int id, string type)
        {
            users.Add2Users(id, type);
        }
        public void Add2State(string product, int amount)
        {
            state.Add2State(product, amount);
        }
    }
}
