using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.UseCases.Todo.CreateTodo;
using Todo.Application.UseCases.TodoLists.CreateTodoList;
using Todo.Application.UseCases.Users.CreateUser;
using Todo.Domain.Entities;

namespace Todo.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => (int)src.Roles))
                .ReverseMap();
            CreateMap<CreateTodoCommand, TodoItem>().ReverseMap();
            CreateMap<CreateTodoListCommand, TodoList>().ReverseMap();
        }
    }
}
