using ToDoListAPI.Models;
using ToDoListAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListAPI.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ToDoItem>> GetAll() => _repository.GetAll();

        public Task<ToDoItem> GetById(int id) => _repository.GetById(id);

        public Task<ToDoItem> Add(ToDoItem toDoItem) => _repository.Add(toDoItem);

        public Task<ToDoItem> Update(ToDoItem toDoItem) => _repository.Update(toDoItem);

        public Task Delete(int id) => _repository.Delete(id);
    }
}
