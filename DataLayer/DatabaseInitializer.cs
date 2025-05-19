using System;
using System.IO;
using System.Reflection;

namespace DataLayer
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            // Set the DataDirectory to the application's base directory
            AppDomain.CurrentDomain.SetData("DataDirectory", 
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Create the database if it doesn't exist
            using (var db = new ShopDataBaseDataContext(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShopDatabase.mdf;Integrated Security=True"))
            {
                if (!db.DatabaseExists())
                {
                    db.CreateDatabase();

                    // Add some initial data
                    db.Users.InsertOnSubmit(new User { Id = 1, Type = "Supplier" });
                    db.Users.InsertOnSubmit(new User { Id = 2, Type = "Customer" });
                    db.Catalogs.InsertOnSubmit(new Catalog { Product = "Apple", Price = 2.50 });
                    db.Catalogs.InsertOnSubmit(new Catalog { Product = "Banana", Price = 3.40 });
                    db.States.InsertOnSubmit(new State { Product = "Apple", Amount = 10 });
                    db.States.InsertOnSubmit(new State { Product = "Banana", Amount = 15 });
                    db.SubmitChanges();
                }
            }
        }
    }
} 