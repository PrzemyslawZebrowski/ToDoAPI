using AutoMapper;
using ToDoAPI.Entities;
using ToDoAPI.Models;

namespace ToDoAPI;

public class ToDoMappingProfile : Profile
{
    public ToDoMappingProfile()
    {
        CreateMap<CreateToDoDto, Todo>();
        CreateMap<Todo, ToDoDto>();
    }
}