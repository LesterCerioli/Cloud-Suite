using CloudSuite.Modules.Application.Handlers.Core.Users;
using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserApiController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<UserApiController>
        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByEmail([FromRoute] Email email)
        {
            try
            {
                var result = await _mediator.Send(new CheckUserExistsByEmailRequest(email));

                if (result.Exists)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by email: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred." });
            }
        }

        // GET api/<UserApiController>/5
        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> GetByCpf([FromRoute] Cpf cpf)
        {
            try
            {
                var result = await _mediator.Send(new CheckUserExistsByCpfRequest(cpf));

                if (result.Exists)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by cpf: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred." });
            }
        }

        // POST api/<UserApiController>
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand commandCreate)
        {
            try
            {
                var result = await _mediator.Send(commandCreate);

                if (result.Errors.Any())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Could not create user." });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred." });
            }
        }
    }
}
