using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Todo.Application.UseCases.Users.AuthenticateUser;
using Todo.Application.UseCases.Users.CreateUser;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
             var result = await _mediator.Send(command);
             return Created("", result);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserQuery query)
        {

            var result = await _mediator.Send(query);
            return Ok(result);

        }
    }
}
