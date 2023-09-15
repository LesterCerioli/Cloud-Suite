using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Messaging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ICountryRepository _countryRepository;
        public CountryApiController(IMediator mediator, ICountryRepository countryRepository)
        {
            _mediator = mediator;
            _countryRepository = countryRepository;
        }

        // GET: api/<CountryApiController>
        [HttpGet]
        public async Task<IEnumerable<Country>> GetList()
        {
           var countries = await _countryRepository.GetList();
           return countries;
        }

        // GET api/<CountryApiController>/5
        [HttpGet("{countryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByName([FromRoute]string countryName)
        {
            try
            {
                var result = await _mediator.Send(new CheckCountryExistsByNameRequest(countryName));

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

        [HttpGet("{code}")]
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostCountry([FromBody] CreateCountryCommand command)
        {
            try
            {
                var country = await _mediator.Send(command);

                if (country.Errors.Any())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { message = "Could not create a country" });
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An internal error ocurred" });
            }

        }


    }
}
