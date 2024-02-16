using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    // GET api/items/5
    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = _itemService.GetById(id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    // POST api/items
    [HttpPost]
    public ActionResult<Item> PostItem([FromBody] Item item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _itemService.Add(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    // DELETE api/items/5
    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        var success = _itemService.Delete(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
