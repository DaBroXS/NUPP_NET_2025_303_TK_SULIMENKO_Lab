using Gadgets.Common.Entities;
using Gadgets.Common.Services.Async;

namespace Gadgets.Tests;

public class AsyncCrudServiceTests
{
    private LaptopAsyncService _service = new();

    private Laptop CreateTestLaptop(string brand = "TestBrand", int ram = 8)
    {
        return new Laptop(brand, 1000, ram, 15.6, true);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddLaptop()
    {
        var laptop = CreateTestLaptop();

        var result = await _service.CreateAsync(laptop);

        Assert.True(result);
        var stored = await _service.ReadAsync(laptop.Id);
        Assert.Equal(laptop.Brand, stored.Brand);
    }

    [Fact]
    public async Task ReadAsync_ShouldReturnLaptopById()
    {
        var laptop = CreateTestLaptop("HP", 16);
        await _service.CreateAsync(laptop);

        var result = await _service.ReadAsync(laptop.Id);

        Assert.NotNull(result);
        Assert.Equal("HP", result.Brand);
        Assert.Equal(16, result.Ram);
    }

    [Fact]
    public async Task ReadAllAsync_ShouldReturnAllLaptops()
    {
        var laptops = new[]
        {
            CreateTestLaptop("Dell"),
            CreateTestLaptop("Acer"),
            CreateTestLaptop("Lenovo")
        };

        foreach (var laptop in laptops)
            await _service.CreateAsync(laptop);

        var result = await _service.ReadAllAsync();

        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task ReadAllAsync_WithPagination_ShouldReturnCorrectSubset()
    {
        for (int i = 0; i < 10; i++)
        {
            await _service.CreateAsync(CreateTestLaptop($"Brand{i}"));
        }

        var result = await _service.ReadAllAsync(page: 1, amount: 3);

        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task UpdateAsync_ShouldModifyLaptop()
    {
        var laptop = CreateTestLaptop("Asus", 8);
        await _service.CreateAsync(laptop);

        laptop.Ram = 32;
        var result = await _service.UpdateAsync(laptop);

        Assert.True(result);
        var updated = await _service.ReadAsync(laptop.Id);
        Assert.Equal(32, updated.Ram);
    }

    [Fact]
    public async Task RemoveAsync_ShouldDeleteLaptop()
    {
        var laptop = CreateTestLaptop("MSI");
        await _service.CreateAsync(laptop);

        var result = await _service.RemoveAsync(laptop);

        Assert.True(result);
        var deleted = await _service.ReadAsync(laptop.Id);
        Assert.Null(deleted);
    }
}