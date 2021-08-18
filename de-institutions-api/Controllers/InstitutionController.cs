using de_institutions_infrastructure.Features.Institution.Queries;
using dss_common.Extensions;
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

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuery request)
        {
            var result = await _mediator.Send(request).ConfigureAwait(false);
            return result.OnBoth(r => r.IsSuccess ? (IActionResult)Ok(r.Value) : NotFound(r.Error));
        }

        [HttpGet("GetByReferenceNumber")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByReference(string refNumber)
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
        public async Task<IActionResult> GetByName(string name)
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
        public async Task<IActionResult> GetSchoolByName(string name)
        {
            var result = await _mediator.Send(new GetSchoolByNameQuery() { Name = name });

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpGet("GetSchoolByReferenceNumber")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSchoolByReference(string refNumber)
        {
            var result = await _mediator.Send(new GetSchoolByReferenceQuery() { InstitutionReference = refNumber });

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Value);
        }
    }
}