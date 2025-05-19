using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repositories;

namespace LogicLayer
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> LoadProductsAsync() => 
            await _repo.GetAllProductsAsync();

        public async Task AddProductAsync(Product product) => 
            await _repo.AddProductAsync(product);

        public async Task UpdateProductAsync(Product product) => 
            await _repo.UpdateProductAsync(product);

        public async Task DeleteProductAsync(int id) => 
            await _repo.DeleteProductAsync(id);

        public async Task UpdateStockAsync(int productId, int quantity) => 
            await _repo.UpdateStockAsync(productId, quantity);
    }
}
