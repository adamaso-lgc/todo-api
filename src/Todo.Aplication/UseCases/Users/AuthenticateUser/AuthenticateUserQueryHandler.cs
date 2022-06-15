using AutoMapper;
using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Exceptions;
using Todo.Application.Repositories;
using Todo.Application.Utilities;
using Todo.Domain.Entities;

namespace Todo.Application.UseCases.Users.AuthenticateUser
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateUserQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserViewModel> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            if(user == null) throw new NotFoundException(nameof(User), request.Email);

            if (_passwordHasher.VerifyHashedPassword(user.Password, request.Password) == PasswordVerificationResult.Failed)
            {
                throw new ApplicationException("Invalid password");
            }

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
