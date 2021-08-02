using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace de_institutions_api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InstituitonController : ControllerBase
    {
        // GET: api/<InstituitonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet("PostCodeSearch/{postcode}", Name = "Get")]
        //[Produces("application/json")]
        //public async Task<ActionResult<IEnumerable<PointerModel>>> GetPointerByPostCode(string postcode)
        //{
        //    var pointerModel = await _context.Pointer.Where(i => i.Postcode == FormatPostCode(postcode) && i.Building_Status == "BUILT" && i.Address_Status == "APPROVED").OrderBy(i => i.Building_Number.Length).ThenBy(i => i.Building_Number).ToListAsync();

        //    if (pointerModel.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(pointerModel);
        //}

        // GET api/<InstituitonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstituitonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstituitonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstituitonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
