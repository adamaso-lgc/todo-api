using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Repositories;
using Todo.Application.Utilities;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetUserByEmail(request.Email);

            if (userExists != null) throw new ApplicationException("User with the same email already exists");

            var user = _mapper.Map<User>(request);

            user.Password = _passwordHasher.HashPassword(request.Password);

            await _userRepository.AddAsync(user);

            return new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Token = JwtGenerator.GenerateAuthToken(user),
            };
        }
    }
}
