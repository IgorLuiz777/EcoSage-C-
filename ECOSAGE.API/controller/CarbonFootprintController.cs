using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.DATA.models.carbonFootprint.dto;
using ECOSAGE.REPOSITORY.activity;
using ECOSAGE.SERVICE.carbonFootprint;
using Microsoft.AspNetCore.Mvc;

namespace ECOSAGE.API.controller
{
    /// <summary>
    /// Controller for managing carbon footprints.
    /// </summary>
    [ApiController]
    [Route("ecosage/carbonfootprints")]
    public class CarbonFootprintController : ControllerBase
    {
        private readonly CarbonFootprintService _carbonFootprintService;

        /// <summary>
        /// Constructor for CarbonFootprintController.
        /// </summary>
        /// <param name="carbonFootprintService">Service for managing carbon footprint operations.</param>
        public CarbonFootprintController(CarbonFootprintService carbonFootprintService)
        {
            _carbonFootprintService = carbonFootprintService;
        }

        /// <summary>
        /// Retrieves all carbon footprints.
        /// </summary>
        /// <returns>A list of carbon footprints or a NoContent status if none exist.</returns>
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

        /// <summary>
        /// Retrieves a carbon footprint by ID.
        /// </summary>
        /// <param name="id">The ID of the carbon footprint.</param>
        /// <returns>The carbon footprint if found, or a NotFound status.</returns>
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

        /// <summary>
        /// Creates a new carbon footprint.
        /// </summary>
        /// <param name="dto">The carbon footprint data transfer object.</param>
        /// <returns>The created carbon footprint with its ID, or a BadRequest status for invalid input.</returns>
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

        /// <summary>
        /// Updates an existing carbon footprint.
        /// </summary>
        /// <param name="id">The ID of the carbon footprint to update.</param>
        /// <param name="carbonFootprint">The updated carbon footprint object.</param>
        /// <returns>A NoContent status if successful, or an error status for invalid input or not found.</returns>
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

        /// <summary>
        /// Deletes a carbon footprint by ID.
        /// </summary>
        /// <param name="id">The ID of the carbon footprint to delete.</param>
        /// <returns>A NoContent status.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carbonFootprintService.DeleteCarbonFootprintAsync(id);
            return NoContent();
        }
    }
}
