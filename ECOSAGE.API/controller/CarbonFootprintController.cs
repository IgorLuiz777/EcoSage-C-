using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.DATA.models.carbonFootprint.dto;
using ECOSAGE.REPOSITORY.activity;
using ECOSAGE.SERVICE.carbonFootprint;
using Microsoft.AspNetCore.Mvc;

namespace ECOSAGE.API.controller
{
    [ApiController]
    [Route("ecosage/carbonfootprints")]
    public class CarbonFootprintController : ControllerBase
    {
        private readonly CarbonFootprintService _carbonFootprintService;

        private readonly CarbonFootprintService _activityRepository;

        public CarbonFootprintController(CarbonFootprintService carbonFootprintService, CarbonFootprintService activityRepository)
        {
            _carbonFootprintService = carbonFootprintService;
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carbonFootprints = await _carbonFootprintService.GetAllCarbonFootprintsAsync();

            if (carbonFootprints == null || carbonFootprints.Count == 0)
            {
                return NoContent();
            }

            return Ok(carbonFootprints);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var carbonFootprint = await _carbonFootprintService.GetCarbonFootprintByIdAsync(id);
                return Ok(carbonFootprint);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarbonFootprintRequestDto dto)
        {
            try
            {
                await _carbonFootprintService.CreateCarbonFootprintAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = dto.UserId }, dto);
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
