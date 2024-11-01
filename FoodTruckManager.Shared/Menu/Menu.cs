namespace FoodTruckManager.Shared.Menu;

public class Menu
{
    public int Id { get; set; }
    public string MenuName { get; set; }
    public string MenuDescription { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
}