using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Messaging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly ILogger<CountryApiController> _logger;
        private readonly IMediator _mediator;
        public CountryApiController(IMediator mediator, ILogger<CountryApiController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

       
        // GET api/<CountryApiController>/5
        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByName([FromRoute]string name)
        {
            try
            {
                var result = await _mediator.Send(new CheckCountryExistsByNameRequest(name));

                if (result.Exists)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Name Not Found." });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching country by name: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error ocurred." });
            }
        }

        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByCode([FromRoute]string code)
        {
            try
            {
                var result = await _mediator.Send(new CheckCountryExistsByCodeRequest(code));

                if (result.Exists)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new { message = "Code not found." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching country by code: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal error ocurred." });
            }
        }

        // POST api/<CountryApiController>
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CreateCountryCommand command)
        {
            try
            {
                var country = await _mediator.Send(command);

                if (country.Errors.Any())
                {
                    
                    return BadRequest(new { message = "Could not create a country" });
                }
                else
                {
                    return Ok();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An internal error ocurred" });
            }

        }


    }
}
