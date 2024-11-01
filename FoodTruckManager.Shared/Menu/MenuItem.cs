namespace FoodTruckManager.Shared.Menu;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Allergies { get; set; } = new List<string>();
    public decimal Price { get; set; }
}