using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;

namespace DataTest
{
    [TestClass]
    public class DataRepositoryTests
    {
        private const string TestConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataShop.mdf;Integrated Security=True";
        private IDataRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = DataRepository.CreateNewRepository(TestConnectionString);
            _repository.ClearAll();
        }

        [TestMethod]
        public void UserTests()
        {
            // Add user
            _repository.AddUser(1, "Supplier");
            
            // Verify user was added
            var user = _repository.GetUser(1);
            Assert.IsNotNull(user);
            Assert.AreEqual("Supplier", user.Type);
            
            // Verify GetAllUsers
            var allUsers = _repository.GetAllUsers().ToList();
            Assert.AreEqual(1, allUsers.Count);
            
            // Remove user
            _repository.RemoveUser(1);
            Assert.IsNull(_repository.GetUser(1));
        }

        [TestMethod]
        public void CatalogTests()
        {
            // Add catalog item
            _repository.AddCatalog("Apple", 2.50f);
            
            // Verify catalog item was added
            var catalog = _repository.GetCatalog("Apple");
            Assert.IsNotNull(catalog);
            Assert.AreEqual(2.50f, catalog.Price);
            
            // Verify GetAllCatalogs
            var allCatalogs = _repository.GetAllCatalogs().ToList();
            Assert.AreEqual(1, allCatalogs.Count);
            
            // Remove catalog item
            _repository.RemoveCatalog("Apple");
            Assert.IsNull(_repository.GetCatalog("Apple"));
        }

        [TestMethod]
        public void StateTests()
        {
            // Add catalog item first
            _repository.AddCatalog("Apple", 2.50f);
            
            // Add state
            _repository.AddState("Apple", 10);
            
            // Verify state was added
            var state = _repository.GetState("Apple");
            Assert.IsNotNull(state);
            Assert.AreEqual(10, state.Amount);
            
            // Update state
            _repository.UpdateState("Apple", 15);
            state = _repository.GetState("Apple");
            Assert.AreEqual(15, state.Amount);
            
            // Verify GetAllStates
            var allStates = _repository.GetAllStates().ToList();
            Assert.AreEqual(1, allStates.Count);
            
            // Remove state
            _repository.RemoveState("Apple");
            Assert.IsNull(_repository.GetState("Apple"));
        }
    }
} 