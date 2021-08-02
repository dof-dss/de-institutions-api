using de_institutions_infrastructure.Features.Institution.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace de_institutions_api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InstitutionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstitutionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll/", Name = "Get")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllInstitutionsQuery());

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }

        //[HttpGet("{refNumber}")]
        //[Produces("application/json")]
        //public string Get(string refNumber)
        //{
        //    return "value";
        //}

        //// POST api/<InstituitonController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<InstituitonController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
    }
}
