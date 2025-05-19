using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;

namespace DataTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting database test...");

            try
            {
                // Set up configuration
                Console.WriteLine("Setting up configuration...");
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                Console.WriteLine("Configuration loaded.");

                // Set up dependency injection
                Console.WriteLine("Setting up dependency injection...");
                var services = new ServiceCollection();
                services.AddDatabaseServices(configuration);
                var serviceProvider = services.BuildServiceProvider();

                Console.WriteLine("Dependency injection configured.");

                // Get the repository
                Console.WriteLine("Getting product repository...");
                var productRepository = serviceProvider.GetRequiredService<IProductRepository>();

                // Test adding a product
                Console.WriteLine("\nTesting product operations:");
                var product = new Product
                {
                    Name = "Test Product",
                    Price = 99.99m,
                    StockQuantity = 10
                };

                Console.WriteLine("Adding test product...");
                await productRepository.AddProductAsync(product);
                Console.WriteLine($"Product added successfully! ID: {product.Id}");

                // Test retrieving products
                Console.WriteLine("\nRetrieving all products...");
                var products = await productRepository.GetAllProductsAsync();
                Console.WriteLine($"Found {products.Count()} products:");
                foreach (var p in products)
                {
                    Console.WriteLine($"- Product: {p.Name}, Price: {p.Price}, Stock: {p.StockQuantity}");
                }

                // Test updating stock
                Console.WriteLine("\nUpdating stock...");
                await productRepository.UpdateStockAsync(product.Id, 15);
                var updatedProduct = await productRepository.GetProductByIdAsync(product.Id);
                Console.WriteLine($"Updated stock quantity: {updatedProduct.StockQuantity}");

                // Test deleting product
                Console.WriteLine("\nDeleting test product...");
                await productRepository.DeleteProductAsync(product.Id);
                Console.WriteLine("Product deleted successfully!");

                // Verify deletion
                var remainingProducts = await productRepository.GetAllProductsAsync();
                Console.WriteLine($"\nRemaining products: {remainingProducts.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

            Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
        }
    }
} 