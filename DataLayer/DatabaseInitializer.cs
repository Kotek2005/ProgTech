using System;
using System.IO;

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
                    }
                }

                // Initialize with default data using the repository
                var repository = DataRepository.CreateNewRepository(connectionString);
                repository.ClearAll();

                // Add initial users
                repository.AddUser(1, "Supplier");
                repository.AddUser(2, "Customer");

                // Add initial catalog items
                repository.AddCatalog("Apple", 2.50f);
                repository.AddCatalog("Banana", 3.40f);

                // Add initial state
                repository.AddState("Apple", 10);
                repository.AddState("Banana", 15);
            }
            catch (Exception ex)
            {
                throw new Exception($"Database initialization failed: {ex.Message}", ex);
            }
        }
    }
} 