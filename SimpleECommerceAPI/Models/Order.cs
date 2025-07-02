namespace SimpleECommerceAPI.Models;

public class Order
{
    //Identity Key
    public int Id { get; set; }

    //Props
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    //FK
    public int UserId { get; set; }

    //Navigations
    public User User { get; set; } = null!;
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}