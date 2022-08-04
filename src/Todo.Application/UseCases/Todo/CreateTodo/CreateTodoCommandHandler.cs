using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Todo.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<TodoItem>(request);

            //todo.Done = false;

            await _todoRepository.AddAsync(todo);

            return todo.Id;
        }
    }
}
