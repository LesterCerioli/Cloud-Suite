using CloudSuite.Modules.Application.Handlers.Core.Users;
using CloudSuite.Modules.Application.Handlers.Token.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IMediator _mediator;

        public CompanyController(ILogger<CompanyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /*
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand createCommand)
        {
            var result = await _mediator.Send(createCommand);
            if(result.Errors.Any())
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("exists/cnpj/{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CnpjExists([FromRoute] string cnpj)
        {
            var result = await _mediator.Send(new CheckCompanyExistsByCnpjRequest(cnpj));
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }
            if (result.Exists)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostCompany([FromBody] CreateCompanyCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.Errors.Any())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Could not create company." });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error occurred." });
            }
        }
        */
    }
}