using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StateApiController> _logger;

        public StateApiController(ILogger<StateApiController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
                        

        }


        // Get api/<DistrictApiController>/5
        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByName([FromRoute] string stateName)
        {
            try
            {
                var result = await _mediator.Send(new CheckStateExistsByStateNameRequest(stateName));
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
                Console.WriteLine($"Error fetching state by name: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }

        }



        // POST api/<StateApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        

        
    }
}
