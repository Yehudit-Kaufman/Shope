using Entite;
using Repository;
using Moq;
using Moq.EntityFrameworkCore;
using DTO;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using Service;


namespace TestProject1
{
    public class OrderTest
    {
        [Fact]
        public async void CheckOrderSum_ValidCredentialsReturnOrder()
        {
            var products = new List<Product>
        {
            new Product { ProductId = 1, Price = 40 },
            new Product { ProductId = 2, Price = 20 }
        };

            var orders = new List<Order>
        {
            new Order
            {
                UserId = 1,
                OrderSum = 100,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2 },
                    new OrderItem { ProductId = 2, Quantity = 1 }
                }
            }
        };

            var mockContext = new Mock<ShopApiContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            var productRepository = new RepositoryProduct(mockContext.Object);
            var orderRepository = new RepositoryOrder(mockContext.Object);
            var mockLogger = new Mock<ILogger<ServiceOrder>>();
            var orderService = new ServiceOrder(orderRepository, productRepository, mockLogger.Object);

            var result = await orderService.AddOrder(orders[0]);
            Assert.Equal(result, orders[0]);
        }
        [Fact]
        public async void CheckOrderSum_UnValidCredentialsReturnExeption()
        {
            var products = new List<Product>
        {
            new Product { ProductId = 1, Price = 40 },
            new Product { ProductId = 2, Price = 20 }
        };

            var invalidOrder = new Order
            {
                UserId = 1,
                OrderSum = 10,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2 },
                    new OrderItem { ProductId = 2, Quantity = 1 }
                }
            };

            var mockContext = new Mock<ShopApiContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(new List<Order>());
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            var productRepository = new RepositoryProduct(mockContext.Object);
            var orderRepository = new RepositoryOrder(mockContext.Object);
            var mockLogger = new Mock<ILogger<ServiceOrder>>();
            var orderService = new ServiceOrder(orderRepository, productRepository, mockLogger.Object);

            await Assert.ThrowsAsync<InvalidOrderException>(async () => await orderService.AddOrder(invalidOrder));

        }
    }
}
