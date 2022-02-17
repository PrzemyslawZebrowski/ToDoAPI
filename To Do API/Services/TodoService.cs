﻿using AutoMapper;
using ToDoAPI.Entities;
using ToDoAPI.Exceptions;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        int CreateTodo(CreateToDoDto dto);
    }

    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _dbContext;
        private readonly IMapper _mapper;

        public TodoService(TodoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public int CreateTodo(CreateToDoDto dto)
        {
            var todoEntity = _mapper.Map<Todo>(dto);

            _dbContext.Todos.Add(todoEntity);
            _dbContext.SaveChanges();
            return todoEntity.Id;
        }
    }
}
