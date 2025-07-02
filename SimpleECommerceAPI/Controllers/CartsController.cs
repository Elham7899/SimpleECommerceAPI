using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleECommerceAPI.Data;
using SimpleECommerceAPI.Models;
using System.Security.Claims;

namespace SimpleECommerceAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly AppDbContext _context;

    public CartController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout([FromBody] List<OrderItem> items)
    {
        if (items.Count == 0) return BadRequest("Cart is empty.");

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        var order = new Order
        {
            UserId = userId,
            Items = new List<OrderItem>()
        };

        foreach (var item in items)
        {
            var product = await _context.Products.FindAsync(item.ProductId);
            if (product == null) return NotFound($"Product {item.ProductId} not found.");

            order.Items.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                PriceAtPurchase = product.Price
            });
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok(new { order.Id, order.CreatedAt, order.Items });
    }

    [HttpGet("my-orders")]
    public async Task<IActionResult> GetMyOrders()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        var orders = await _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return Ok(orders);
    }
}