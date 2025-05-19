using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class LINQProductRepository : IProductRepository
    {
        private readonly ShopDataLINQDataContext _context;

        public LINQProductRepository()
        {
            _context = new ShopDataLINQDataContext();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.Run(() => _context.Products.ToList());
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Task.Run(() => _context.Products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await Task.Run(() => _context.Products.FirstOrDefault(p => p.Name == name));
        }

        public async Task AddProductAsync(Product product)
        {
            await Task.Run(() =>
            {
                _context.Products.InsertOnSubmit(product);
                _context.SubmitChanges();
            });
        }

        public async Task UpdateProductAsync(Product product)
        {
            await Task.Run(() =>
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.StockQuantity = product.StockQuantity;
                    _context.SubmitChanges();
                }
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            await Task.Run(() =>
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    _context.Products.DeleteOnSubmit(product);
                    _context.SubmitChanges();
                }
            });
        }

        public async Task UpdateStockAsync(int productId, int quantity)
        {
            await Task.Run(() =>
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    product.StockQuantity = quantity;
                    _context.SubmitChanges();
                }
            });
        }
    }
} 