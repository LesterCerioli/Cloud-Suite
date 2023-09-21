using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.Handlers.Core.Districts.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictApiController : ControllerBase
    {
        private readonly ILogger<DistrictApiController> _logger;
        private readonly IMediator _mediator;

        public DistrictApiController(ILogger<DistrictApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateDistrictCommand commandCreate)
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
                Console.WriteLine($"Error fetching district by name: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }
    }
}
