using ToDoAPI.Entities;
using ToDoAPI.Exceptions;

namespace ToDoAPI.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
    }

    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _dbContext;

        public TodoService(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Todo> GetAll()
        {
            if (!_dbContext.Todos.Any())
            {
                throw new NotFoundException("Not found any todos");
            }

            return new List<Todo>(_dbContext.Todos);
        }

        public Todo GetById(int id)
        {
            var todo = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
            {
                throw new NotFoundException("Not found todo");
            }

            return todo;
        }
    }
}
