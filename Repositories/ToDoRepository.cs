using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _context;

        public ToDoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAll()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetById(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<ToDoItem> Add(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem> Update(ToDoItem toDoItem)
        {
            _context.Entry(toDoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toDoItem;
        }

        public async Task Delete(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
