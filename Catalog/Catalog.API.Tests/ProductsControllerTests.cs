using Catalog.API.Controllers;
using Catalog.API.Models;
using Catalog.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalog.API.Tests
{
    public class ProductsControllerTests
    {

        /*
         *   Bir müşteri olarak
         *   Uygun ürünleri aramak istiyorum
         *   Böylelikle ürün detaylarını görebilir ve aradığım ürünü bulabilirim
         * 
         *   Given -> Bir müşteri olarak bir ürün adı gireceğim         *   
         *   When  -> Ürün arama işlemini başlattığımda
         *   Then  -> Ürün adında belirttiğim isimdeki ürünler listelenecek.
         *   
         *   Given -> Bir müşteri olarak bir ürün adı gireceğim         *   
         *   When  -> Ürün arama işlemini başlattığımda
         *   Then  -> Ürün açıklamasında belirttiğim isimdeki ürünler listelenecek.
         *   
         * 
         */
        //[Fact]
        //public void ItExists()
        //{
        //    var controller = new Catalog.API.Controllers.ProductsController();
        //    var response = controller.Search("name");

        //}

        ProductsController controller;
        public ProductsControllerTests()
        {
            //FakeProductService fakeProductService = new FakeProductService();
            //AnotherProductService anotherProductService = new AnotherProductService();



            //productServiceMock.Setup(ps => ps.SearchProductsByName(It.IsAny<string>())).Returns(() => new List<Product>() {
            //      new(){ Name="Laptop", Description="Laptop x", Price=55000},
            //      new(){ Name="Ayakkabı", Description="Laptop x", Price=550},
            //      new(){ Name="Ayakkabı çekeceği", Description="Laptop x", Price=55},
            //});

            Mock<IProductService> productServiceMock = new Mock<IProductService>();

            productServiceMock.Setup(ps => ps.SearchProductsByName("Laptop")).Returns(() => new List<Product>() {
                  new(){ Name="Laptop", Description="Laptop x", Price=55000}
            });

            productServiceMock.Setup(ps => ps.SearchProductsByName("Ayak")).Returns(() => new List<Product>() {
                  new(){ Name="Ayakkabı", Description="Laptop x", Price=550},
                  new(){ Name="Ayakkabı çekeceği", Description="Laptop x", Price=55},
            });


            controller = new ProductsController(productServiceMock.Object);
        }

        [Fact]
        public void It_Return_OkObject_Result()
        {
            var response = controller.Search("Lap");
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public void It_Return_Product_Collection()
        {
            var response = controller.Search("Lap") as OkObjectResult;
            Assert.NotNull(response.Value);
            Assert.IsAssignableFrom<IEnumerable<Product>>(response.Value);


        }

        [Fact]
        public void It_Return_One_Product_Given_Full_Name()
        {
            var response = (IEnumerable<Product>)(controller.Search("Laptop") as OkObjectResult).Value;
            Assert.Equal(1, response.Count());
            Assert.Equal("Laptop", response.First().Name);

        }

        [Fact]
        public void It_Return_Product_Given_Contain_String()
        {
            var response = (IEnumerable<Product>)(controller.Search("Ayak") as OkObjectResult).Value;

            Assert.Equal(2, response.Count());

        }
    }
}