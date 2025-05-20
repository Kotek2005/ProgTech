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
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);

                string dbPath = Path.Combine(baseDir, "DataShop.mdf");
                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
                //connection string, integrated security true bylo na wykaldzie
                //chodzi o permission itp
                using (var db = new ShopDataBaseDataContext(connectionString))
                {//using bylo na wykladzie
                    if (!db.DatabaseExists())
                    {
                        db.CreateDatabase();
                    }
                }
                //tu chyba wywali na innym komputerze bo powinno
                var repository = DataRepository.CreateNewRepository(connectionString);
                repository.ClearAll();

                repository.AddUser(1, "Supplier");
                repository.AddUser(2, "Customer");

                repository.AddCatalog("Apple", 2.50f);
                repository.AddCatalog("Banana", 3.40f);

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