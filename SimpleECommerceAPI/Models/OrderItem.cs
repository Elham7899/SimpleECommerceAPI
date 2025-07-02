namespace SimpleECommerceAPI.Models;

public class OrderItem
{
    //Identity Key
    public int Id { get; set; }

    //Porps
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    //Fk
    public int ProductId { get; set; }

    //Navigations
    public Product Product { get; set; } = null!;
}