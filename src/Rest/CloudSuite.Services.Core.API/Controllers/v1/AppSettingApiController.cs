using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]

    public class AppSettingApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        
        public AppSettingApiController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [Route("{value}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByValue([FromRoute] string value)
        {
            try
            {
                var result = await _mediator.Send(new CheckAppSettingExistsByValueRequest(value));
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
                Console.WriteLine($"Error fetching App setting by App Setting: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromBody] CreateAppSettingCommand commandCreate)
        {
            try
            {                
                    var result = await _mediator.Send(commandCreate);

                    if (result.Errors.Any())
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(new { message = "Could not create app setting." });
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

    }
   }
