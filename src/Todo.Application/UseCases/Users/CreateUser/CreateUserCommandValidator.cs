using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.UseCases.Users.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is empty.")
            .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters.");

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is empty.")
            .Length(5, 100).WithMessage("The Email must have between 5 and 100 characters.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty.");
        }
    }
}
