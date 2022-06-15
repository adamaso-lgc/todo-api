using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.UseCases.Users.AuthenticateUser
{
    public class AuthenticateUserQuery : IRequest<UserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
