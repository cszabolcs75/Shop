using Logic;
using Models;
using Moq;
using NUnit.Framework;
using Repository;

namespace Tester
{
    [TestFixture]
    public class TesterClass
    {
        [Test]
        public void CreateProductTest()
        {
                var productRepositoryMock = new Mock<IProductRepository>();
                var productLogic = new ProductLogic(productRepositoryMock.Object);

                var product = new Product
                {
                    Id = 1,
                    Name = "Test Product",
                    Price = 10
                };
                
                productLogic.CreateProduct(product);

                productRepositoryMock.Verify(repo => repo.CreateProduct(product), Times.Once);
        }
        
    }
}
