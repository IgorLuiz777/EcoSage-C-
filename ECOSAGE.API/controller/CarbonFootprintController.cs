using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.SERVICE.carbonFootprint;
using Microsoft.AspNetCore.Mvc;

namespace ECOSAGE.API.controller
{
    [ApiController]
    [Route("ecosage/carbonfootprints")]
    public class CarbonFootprintController : ControllerBase
    {
        private readonly CarbonFootprintService _carbonFootprintService;

        public CarbonFootprintController(CarbonFootprintService carbonFootprintService)
        {
            _carbonFootprintService = carbonFootprintService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carbonFootprints = await _carbonFootprintService.GetAllCarbonFootprintsAsync();
            return Ok(carbonFootprints);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carbonFootprint = await _carbonFootprintService.GetCarbonFootprintByIdAsync(id);
            if (carbonFootprint == null)
                return NotFound();

            return Ok(carbonFootprint);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarbonFootprint carbonFootprint)
        {
            try
            {
                await _carbonFootprintService.AddCarbonFootprintAsync(carbonFootprint);
                return CreatedAtAction(nameof(GetById), new { id = carbonFootprint.CarbonFootprintId }, carbonFootprint);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarbonFootprint carbonFootprint)
        {
            if (id != carbonFootprint.CarbonFootprintId)
                return BadRequest("ID NOT FOUND.");

            try
            {
                await _carbonFootprintService.UpdateCarbonFootprintAsync(carbonFootprint);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carbonFootprintService.DeleteCarbonFootprintAsync(id);
            return NoContent();
        }
    }
}
