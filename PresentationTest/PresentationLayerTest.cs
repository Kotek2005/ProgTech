using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PresentationTest
{
    [TestClass]
    public class PresentationLayerTest
    {
        private FakeService _fakeService;
        private UsersViewModel _usersViewModel;
        private CatalogViewModel _catalogViewModel;
        private StateViewModel _stateViewModel;

        [TestInitialize]
        public void Setup()
        {
            _fakeService = new FakeService();
            _usersViewModel = new UsersViewModel(_fakeService);
            _catalogViewModel = new CatalogViewModel(_fakeService);
            _stateViewModel = new StateViewModel(_fakeService);
        }

        [TestMethod]
        public void UsersViewModel_LoadUsers_ShouldLoadUsersFromService()
        {
            // Arrange
            _fakeService.AddUser(1, "Admin");
            _fakeService.AddUser(2, "User");

            // Act
            _usersViewModel.RefreshUsers();

            // Assert
            Assert.AreEqual(2, _usersViewModel.Users.Count);
            Assert.IsTrue(_usersViewModel.Users.Any(u => u.id == 1 && u.type == "Admin"));
            Assert.IsTrue(_usersViewModel.Users.Any(u => u.id == 2 && u.type == "User"));
        }

        [TestMethod]
        public void CatalogViewModel_LoadProducts_ShouldLoadProductsFromService()
        {
            // Arrange
            _fakeService.AddProduct("Product1", 10.0f);
            _fakeService.AddProduct("Product2", 20.0f);

            // Act
            _catalogViewModel.RefreshProducts();

            // Assert
            Assert.AreEqual(2, _catalogViewModel.Products.Count);
            Assert.IsTrue(_catalogViewModel.Products.Any(p => p.name == "Product1" && p.price == 10.0f));
            Assert.IsTrue(_catalogViewModel.Products.Any(p => p.name == "Product2" && p.price == 20.0f));
        }

        [TestMethod]
        public void StateViewModel_LoadInventory_ShouldLoadInventoryFromService()
        {
            // Arrange
            _fakeService.AddToState("Product1", 5);
            _fakeService.AddToState("Product2", 10);

            // Act
            _stateViewModel.RefreshState();

            // Assert
            Assert.AreEqual(2, _stateViewModel.Inventory.Count);
            Assert.IsTrue(_stateViewModel.Inventory.Any(s => s.product == "Product1" && s.amount == 5));
            Assert.IsTrue(_stateViewModel.Inventory.Any(s => s.product == "Product2" && s.amount == 10));
        }
/*
        [TestMethod]
        public void UsersViewModel_RefreshUsers_ShouldLoadUsersFromService()
        {
            // Arrange
            _fakeService.AddUser(1, "Admin");
            _fakeService.AddUser(2, "User");

            // Act
            _usersViewModel.RefreshUsers();

            // Assert
            Assert.AreEqual(2, _usersViewModel.Users.Count);
            Assert.IsTrue(_usersViewModel.Users.Any(u => u.id == 1 && u.type == "Admin"));
            Assert.IsTrue(_usersViewModel.Users.Any(u => u.id == 2 && u.type == "User"));
        }

        [TestMethod]
        public void CatalogViewModel_RefreshProducts_ShouldLoadProductsFromService()
        {
            // Arrange
            _fakeService.AddProduct("Product1", 10.0f);
            _fakeService.AddProduct("Product2", 20.0f);

            // Act
            _catalogViewModel.RefreshProducts();

            // Assert
            Assert.AreEqual(2, _catalogViewModel.Products.Count);
            Assert.IsTrue(_catalogViewModel.Products.Any(p => p.name == "Product1" && p.price == 10.0f));
            Assert.IsTrue(_catalogViewModel.Products.Any(p => p.name == "Product2" && p.price == 20.0f));
        }

        [TestMethod]
        public void StateViewModel_RefreshState_ShouldLoadInventoryFromService()
        {
            // Arrange
            _fakeService.AddToState("Product1", 5);
            _fakeService.AddToState("Product2", 10);

            // Act
            _stateViewModel.RefreshState();

            // Assert
            Assert.AreEqual(2, _stateViewModel.Inventory.Count);
            Assert.IsTrue(_stateViewModel.Inventory.Any(s => s.product == "Product1" && s.amount == 5));
            Assert.IsTrue(_stateViewModel.Inventory.Any(s => s.product == "Product2" && s.amount == 10));
        }*/
    }
}
