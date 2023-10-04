using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Services.Core.API.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class CityApiController : ControllerBase
    {

        private readonly ILogger<CityApiController> _logger;
        private readonly IMediator _mediator;

        public CityApiController(ILogger<CityApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCityCommand commandCreate)
        {
            try
            {
                var result = await _mediator.Send(commandCreate);
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
                Console.WriteLine($"Error fetching city by name: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }

        }


        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByCityName([FromRoute] string cityName)
        {
            try
            {
                var result = await _mediator.Send(new CheckCityExistsByCityNameRequest(cityName));
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
                Console.WriteLine($"Error fetching city by name: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }
    }
}