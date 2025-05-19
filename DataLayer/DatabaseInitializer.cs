using System;
using System.IO;
using System.Reflection;

namespace DataLayer
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            try
            {
                // Get the output directory
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);

                string dbPath = Path.Combine(baseDir, "DataShop.mdf");
                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";

                // Create the database if it doesn't exist
                using (var db = new ShopDataBaseDataContext(connectionString))
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
            catch (Exception ex)
            {
                throw new Exception($"Database initialization failed: {ex.Message}", ex);
            }
        }
    }
} 