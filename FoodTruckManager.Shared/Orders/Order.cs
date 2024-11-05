using FoodTruckManager.Shared.Menu;

namespace FoodTruckManager.Shared.Orders;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<MenuItem> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(item 
        => item.Price);
    public OrderStatus Status { get; set; }
}