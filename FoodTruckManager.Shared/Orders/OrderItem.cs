using FoodTruckManager.Shared.Menu;

namespace FoodTruckManager.Shared.Orders;

public class OrderItem
{
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
}