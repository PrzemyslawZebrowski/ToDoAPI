using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ToDoAPI.Authorization;
using ToDoAPI.Entities;
using ToDoAPI.Exceptions;
using ToDoAPI.Models;

namespace ToDoAPI.Services;

public interface ITodoService
{
    IEnumerable<TodoDto> GetAll();
    Todo GetById(int id);
    int CreateTodo(CreateTodoDto dto);
    public void DeleteTodo(int id);
    void UpdateTodo(int id, UpdateTodoDto dto);
}

public class TodoService : ITodoService
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _contextService;
    private readonly TodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public TodoService(TodoDbContext dbContext, IMapper mapper, IUserContextService contextService,
        IAuthorizationService authorizationService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _contextService = contextService;
        _authorizationService = authorizationService;
    }

    public IEnumerable<TodoDto> GetAll()
    {
        var todos = _dbContext.Todos.Where(t => t.CreatedById == _contextService.UserId!.Value);

        if (!todos.Any()) throw new NotFoundException("Not found any todos");

        var toDoDtos = _mapper.Map<List<TodoDto>>(todos);

        return toDoDtos;
    }

    public Todo GetById(int id)
    {
        var todo = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
        if (todo is null) throw new NotFoundException("Not found todo");

        var authorizationResult = _authorizationService
            .AuthorizeAsync(_contextService.User!, todo, new SameAuthorRequirement()).Result;

        if (!authorizationResult.Succeeded) throw new ForbidException();

        return todo;
    }

    public int CreateTodo(CreateTodoDto dto)
    {
        var todoEntity = _mapper.Map<Todo>(dto);

        todoEntity.CreatedById = _contextService.UserId!.Value;

        _dbContext.Todos.Add(todoEntity);
        _dbContext.SaveChanges();
        return todoEntity.Id;
    }

    public void DeleteTodo(int id)
    {
        var todo = _dbContext.Todos.FirstOrDefault(t => t.Id == id);

        if (todo is null)
            throw new NotFoundException("Not found todo");

        var authorizationResult = _authorizationService
            .AuthorizeAsync(_contextService.User!, todo, new SameAuthorRequirement()).Result;

        if (!authorizationResult.Succeeded) throw new ForbidException();

        _dbContext.Todos.Remove(todo);

        _dbContext.SaveChanges();
    }

    public void UpdateTodo(int id, UpdateTodoDto dto)
    {
        var todo = _dbContext.Todos.FirstOrDefault(t => t.Id == id);

        if (todo is null)
            throw new NotFoundException("Not found todo");

        var authorizationResult = _authorizationService
            .AuthorizeAsync(_contextService.User!, todo, new SameAuthorRequirement()).Result;

        if (!authorizationResult.Succeeded) throw new ForbidException();

        if (!string.IsNullOrEmpty(dto.Title))
            todo.Title = dto.Title;

        if (!string.IsNullOrEmpty(dto.Description))
            todo.Description = dto.Description;

        if (dto.Deadline.HasValue)
            todo.Deadline = dto.Deadline;

        if (dto.IsCompleted.HasValue)
            todo.IsCompleted = dto.IsCompleted.Value;

        _dbContext.SaveChanges();
    }
}