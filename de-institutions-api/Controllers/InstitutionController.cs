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

        [HttpGet("GetAll/")]
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

        [HttpGet("GetByReferenceNumber")]
        [Produces("application/json")]
        public async Task<ActionResult> GetByReference(string refNumber)
        {
            var result = await _mediator.Send(new GetInstitutionByRefQuery() { InstitutionReference = refNumber });

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("SearchByName")]
        [Produces("application/json")]
        public async Task<ActionResult> GetByName(string name)
        {
            var result = await _mediator.Send(new GetInstitutionByNameQuery() { Name = name });

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("SearchSchoolByName")]
        [Produces("application/json")]
        public async Task<ActionResult> GetSchoolByName(string name)
        {
            var result = await _mediator.Send(new GetSchoolByNameQuery() { Name = name });

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }
    }
}