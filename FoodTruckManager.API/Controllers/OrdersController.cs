using FoodTruckManager.Shared.Menu;
using FoodTruckManager.Shared.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : Controller
{
    private List<Order> _orders = new();

    public OrdersController()
    {
        var order = new Order()
        {
            Id = 1,
            OrderDate = DateTime.Now,
            Items = new List<MenuItem>(){new MenuItem(){Name = "Fries", Price = 1}, new MenuItem(){Name = "Fries", Price = 1}}
        };
        _orders.Add(order);
    }

    // GET: api/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await Task.FromResult(Ok(_orders));
    }

    // GET: api/orders/{id} 
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    // POST: api/orders
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        order.Id = _orders.Count + 1;
        order.OrderDate = DateTime.UtcNow;
        order.Status = OrderStatus.Pending;
        
        _orders.Add(order);
    
        return await Task.FromResult(CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order));
    }

    // PUT: api/orders/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatus status)
    {
        var order = await Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
        if (order == null)
        {
            return NotFound();
        }

        order.Status = status;
        return NoContent();
    }
}



