using AutoMapper;
using ToDoAPI.Entities;
using ToDoAPI.Models;

namespace ToDoAPI;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile()
    {
        CreateMap<CreateTodoDto, Todo>();
        CreateMap<Todo, TodoDto>();
    }
}