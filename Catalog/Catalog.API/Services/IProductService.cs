using Catalog.API.Models;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        IEnumerable<Product> SearchProductsByName(string productName);
    }
}
