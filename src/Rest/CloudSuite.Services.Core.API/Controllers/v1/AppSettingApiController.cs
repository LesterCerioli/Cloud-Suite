using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloudSuite.Services.Core.API.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]

    public class AppSettingApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAppSettingRepository _appSettingRepository;
        
        public AppSettingApiController(IMediator mediator, IAppSettingRepository appSettingRepository)
        {
            _mediator = mediator;
            _appSettingRepository = appSettingRepository;
        }


        [HttpGet]
        [Route("{value}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByAppSetting([FromRoute] string value)
        {
            try
            {
                var result = await _mediator.Send(new CheckAppSettingExistsByAppSettingRequest(value));
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



        [HttpGet]
        [Route("{module}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByModule([FromRoute] string module)
        {
            try
            {
                var result = await _mediator.Send(new CheckAppSettingExistsByModuleRequest(module));
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
                Console.WriteLine($"Error fetching app setting by module: {ex.Message}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An internal Server Error" });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<AppSetting>> GetAll()
        {
            var appsetting = await _appSettingRepository.GetAll();
            
            return appsetting;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateAppSettingCommand command)
        {
            try
            {                
                    var result = await _mediator.Send(command);

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
