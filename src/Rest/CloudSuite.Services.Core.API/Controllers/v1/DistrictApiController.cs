using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DistrictApiController> _logger;

        public DistrictApiController(ILogger<DistrictApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        // Get api/<DistrictApiController>/5
        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var result = await _mediator.Send(new CheckDistrictExistsByNameRequest(name));
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
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateDistrictCommand createCommand)
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
