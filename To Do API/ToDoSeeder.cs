using ToDoAPI.Entities;

namespace ToDoAPI
{
    public class ToDoSeeder
    {
        private readonly TodoDbContext _dbContext;

        public ToDoSeeder(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Todos.Any()) 
                return;

            var todos = new List<Todo>()
            {
                new Todo()
                {
                    Title = "Zadanie matematyka",
                    Description = "Podrecznik, strona 32, zadanie 6",
                    IsCompleted = false,
                    Deadline = new DateTime(2023, 2, 13)
                },
                new Todo()
                {
                    Title = "Urodziny kuby",
                    Description = "Kupic prezent",
                    IsCompleted = false,
                    Deadline = new DateTime(2023, 5, 11)
                }
            };
            _dbContext.Todos.AddRange(todos);
            _dbContext.SaveChanges();

        }
    }
}
