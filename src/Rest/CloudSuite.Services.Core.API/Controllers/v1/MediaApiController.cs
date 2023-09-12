using CloudSuite.Modules.Application.Handlers.Core.Medias.Requests;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Core.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class MediaApiController : ControllerBase
    {

        private readonly IMediaRepository _mediaRepository;
        private readonly IMediator _mediator;

        public MediaApiController(IMediator mediator, IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
            _mediator = mediator;
        }

        // GET: api/<CountryApiController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Media>> GetList()
        {
            return await _mediaRepository.GetList();
        }

        // GET api/<CountryApiController>/5
        [HttpGet("")]
        public async Task<ActionResult> GetByFileName([FromRoute] string fileName)
        {
            try
            {
                var result = await _mediator.Send(new CheckMediaExistsByFileNameRequest(fileName));
                if (result.Exists)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound(new {message = "File not found.s"});
                }
            }
            catch (System.Exception)
            {

                Console.WriteLine($"Error fetching ")
            }
        }

        // POST api/<CountryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    internal class CheckMediaExistsByCaptionRequest : IRequest<object>
    {
    }
}
