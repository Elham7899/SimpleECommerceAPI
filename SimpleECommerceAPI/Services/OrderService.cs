using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SimpleECommerceAPI.Data;
using SimpleECommerceAPI.Models;
using System.Security.Claims;

namespace SimpleECommerceAPI.Services;

public class OrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateAsync(List<OrderItem> items, int userId)
    {
        if (items.Any())
        {
            var order = new Order
            {
                UserId = userId,
                Items = new List<OrderItem>()
            };

            foreach (var item in items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    order.Items.Add(new OrderItem
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        PriceAtPurchase = product.Price
                    });
                }
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        else return null;
    }

    public async Task<List<Order>> GetAllOrdersAsync(int userId)
    {
        return await _context.Orders.Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }
}
