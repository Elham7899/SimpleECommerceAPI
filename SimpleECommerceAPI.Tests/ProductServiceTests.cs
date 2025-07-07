using Xunit;
using SimpleECommerceAPI.Data;
using SimpleECommerceAPI.Models;
using SimpleECommerceAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SimpleECommerceAPI.Tests;

public class ProductServiceTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
      .UseInMemoryDatabase("TestDb_" + Guid.NewGuid())
      .EnableSensitiveDataLogging()
      .LogTo(Console.WriteLine)
      .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddProduct()
    {
        // Arrange
        var db = GetDbContext();
        var service = new ProductService(db);
        var product = new Product { Name = "Test Product", Price = 10.5M, Stock = 5,Description = "Test Descriptuin" };

        // Act
        var result = await service.CreateAsync(product);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(1, await db.Products.CountAsync());
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsCorrectProduct()
    {
        // Arrange
        var db = GetDbContext();
        var service = new ProductService(db);
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Price = 10.5M,
            Stock = 5,
            Description = "Test Descriptuin"
        };
        db.Products.Add(product);
        await db.SaveChangesAsync();

        // Act
        var found = await service.GetByIdAsync(product.Id);

        // Assert
        Assert.NotNull(found);
        Assert.Equal("Test Product", found?.Name);
    }
}
