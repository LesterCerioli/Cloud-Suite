using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<VendorApiController> _logger;

        public VendorApiController(ILogger<VendorApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        // Get api/<VendorApiController>/5
        [HttpGet]
        [Route("{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByCnpj([FromRoute] Cnpj cnpj)
        {
            try
            {
                var result = await _mediator.Send(new CheckVendorExistsByCnpjRequest(cnpj));
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

        // POST api/<VendorApiController>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateVendorCommand createCommand)
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
                Console.WriteLine($"Error fetching user by cnpj: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }
    }
}