using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.UseCases.Users.AuthenticateUser
{
    public class AuthenticateUserQueryValidation : AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidation()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is empty.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty.");
        }
    }
}
