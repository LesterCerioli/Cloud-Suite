using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class CityApiController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<CityApiController> _logger;
        private readonly ICityRepository _cityRepository;

        public CityApiController(ILogger<CityApiController> logger, IMediator mediator, ICityRepository cityRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<City>> GetList()
        {
            var cities = await _cityRepository.GetList();
            return cities;
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
                Console.WriteLine($"Error fetching user by name: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCity)
        {
            try
            {
                var result = await _mediator.Send(createCity);
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