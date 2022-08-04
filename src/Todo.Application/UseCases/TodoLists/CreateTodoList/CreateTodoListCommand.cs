using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.TodoLists.CreateTodoList
{
    public partial class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Color { get; set; }

        public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
        {
            private readonly ITodoListRepository _todoListRepository;
            private readonly IMapper _mapper;

            public CreateTodoListCommandHandler(ITodoListRepository todoListRepository, IMapper mapper)
            {
                _todoListRepository = todoListRepository;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
            {
                var todoList = _mapper.Map<TodoList>(request);

                await _todoListRepository.AddAsync(todoList);

                return todoList.Id;

            }
        }
    }
}
