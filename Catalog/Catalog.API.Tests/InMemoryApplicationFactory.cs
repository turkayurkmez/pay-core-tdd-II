using Catalog.API.Models;
using Catalog.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Catalog.API.Tests
{
    public class InMemoryApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(sp =>
                   {
                       Mock<IProductService> productServiceMock = new Mock<IProductService>();

                       productServiceMock.Setup(ps => ps.SearchProductsByName("Laptop")).Returns(() => new List<Product>() {
                  new(){ Name="Laptop", Description="Laptop x", Price=55000}       });

                       productServiceMock.Setup(ps => ps.SearchProductsByName("Ayak")).Returns(() => new List<Product>() {
                  new(){ Name="Ayakkabı", Description="Laptop x", Price=550},
                  new(){ Name="Ayakkabı çekeceği", Description="Laptop x", Price=55}});

                       sp.AddScoped(productServiceMock.Object.GetType());
                   });
        }
    }
}
