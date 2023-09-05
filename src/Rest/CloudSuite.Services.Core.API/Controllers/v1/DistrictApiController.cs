using CloudSuite.Modules.Application.Handlers.Core.Districts;
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

        public IMediator Get_mediator()
        {
            return _mediator;
        }

        //public async Task<IActionResult> Post([FromBody] CreateDistrictCommand createCommand, IMediator _mediator)
        //{
            

        //}
        
        
        
    }

    
}
