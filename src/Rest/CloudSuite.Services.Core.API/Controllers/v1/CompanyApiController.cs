using CloudSuite.Modules.Application.Handlers.Core.Companies;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CompanyApiController> _logger;

        public CompanyApiController(ILogger<CompanyApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        // Get api/<CompanyApiController>/5
        [HttpGet]
        [Route("{fantasyname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByFantasyName([FromRoute] string fantasyname)
        {
            try
            {
                var result = await _mediator.Send(new CheckCompanyExistsByFantasyNameRequest(fantasyname));
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by fantasyname: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

        [HttpGet]
        [Route("{registername}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByRegisterName([FromRoute] string registername)
        {
            try
            {
                var result = await _mediator.Send(new CheckCompanyExistsByRegisterNameRequest(registername));
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by registername: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

        [HttpGet]
        [Route("{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByCnpj([FromRoute] Cnpj cnpj)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by cnpj: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

        // POST api/<CompanyApiController>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCommand)
        {
            try
            {
                var result = await _mediator.Send(createCommand);
                if (result.Errors.Any())
                {
                    return BadRequest(result);
                }

                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by email: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }
    }
}
