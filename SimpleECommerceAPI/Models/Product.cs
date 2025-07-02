namespace SimpleECommerceAPI.Models;

public class Product
{
    //Identity Key
    public int Id { get; set; }

    //Props
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
