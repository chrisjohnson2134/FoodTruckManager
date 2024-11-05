using System.Net;
using FoodTruckManager.API.Context;
using FoodTruckManager.Shared.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private List<Menu> _menus;
    private List<MenuItem> _menuItems= new List<MenuItem>();

    public MenuController()
    {

        _menus = new() { new Menu() { MenuName = "Lunch", MenuItems = _menuItems } };
    }
    
    // GET: api/menu
    [HttpGet]
    public ActionResult<Menu> GetManus()
    {
        return Ok(_menus);
    }
    
    //api/menu/menuItems
    [HttpGet("/menuItems")]
    public async Task<ActionResult<List<MenuItem>>> GetMenuItems()
    {
        AppDataContext a = new AppDataContext();
        _menuItems = await a.MenuItems.ToListAsync();
        return _menuItems;
    }

    // GET: api/menu/{id}
    [HttpGet("{id}")]
    public ActionResult<Menu> GetMenu(int id)
    {
        var menuItem = _menus.FirstOrDefault(m => m.Id == id);
        if (menuItem == null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }

    // POST: api/menu
    [HttpPost] 
    public ActionResult<Menu> CreateMenu(Menu menu)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        menu.Id = _menus.Count + 1;
        _menus.Add(menu);

        return CreatedAtAction(nameof(Menu), new { id = menu.Id }, menu);
    }
    
    [HttpPost("/MenuItem")] 
    public ActionResult<MenuItem> CreateMenuItem(MenuItem menuItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        AppDataContext a = new AppDataContext();
        a.MenuItems.Add(menuItem);
        a.SaveChanges();
        _menuItems.Add(menuItem);
        var actionResult = new AcceptedResult()
        {
            StatusCode = StatusCodes.Status201Created,
            Value = menuItem
        };
        return actionResult;
    }

    // PUT: api/menu/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateMenu(int id, Menu menuItem)
    {
        if (id != menuItem.Id)
        {
            return BadRequest();
        }

        var existingItem = _menus.FirstOrDefault(m => m.Id == id);
        if (existingItem == null)
        {
            return NotFound();
        }

        var index = _menus.IndexOf(existingItem);
        _menus[index] = menuItem;

        return NoContent();
    }

    // DELETE: api/menu/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteMenuItem(int id)
    {
        var menuItem = _menus.FirstOrDefault(m => m.Id == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        _menus.Remove(menuItem);
        return NoContent();
    }
}