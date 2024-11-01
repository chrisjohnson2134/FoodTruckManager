namespace FoodTruckManager.Shared.Orders;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(item 
        => item.MenuItem.Price * item.Quantity);
    public OrderStatus Status { get; set; }
}