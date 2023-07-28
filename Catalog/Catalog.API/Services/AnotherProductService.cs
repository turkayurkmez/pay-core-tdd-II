using Catalog.API.Models;

namespace Catalog.API.Services
{
    public class AnotherProductService : IProductService
    {
        private List<Product> _products;
        public AnotherProductService()
        {
            _products = new List<Product>
            {
                new(){ Name="Laptop", Description="Laptop x", Price=55000},
                new(){ Name="Ayakkabı", Description="Laptop x", Price=550},
                new(){ Name="Ayakkabı çekeceği", Description="Laptop x", Price=55},

            };
        }
        public IEnumerable<Product> SearchProductsByName(string productName)
        {
            return _products.Where(p => p.Name.Contains(productName));
        }
    }
}
