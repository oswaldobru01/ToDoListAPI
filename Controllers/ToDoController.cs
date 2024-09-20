using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _toDoService.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _toDoService.GetById(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ToDoItem toDoItem)
    {
        var createdItem = await _toDoService.Add(toDoItem);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ToDoItem toDoItem)
    {
        if (id != toDoItem.Id) return BadRequest();
        var updatedItem = await _toDoService.Update(toDoItem);
        return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _toDoService.Delete(id);
        return NoContent();
    }
}
