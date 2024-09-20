using ToDoListAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListAPI.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAll();
        Task<ToDoItem> GetById(int id);
        Task<ToDoItem> Add(ToDoItem toDoItem);
        Task<ToDoItem> Update(ToDoItem toDoItem);
        Task Delete(int id);
    }
}
