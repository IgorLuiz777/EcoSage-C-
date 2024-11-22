using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.activity.dto;
using ECOSAGE.SERVICE.activity;
using Microsoft.AspNetCore.Mvc;

namespace ECOSAGE.API.controller
{
    [Route("ecosage/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityService _activityService;

        public ActivityController(ActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Adds a new energy activity.
        /// </summary>
        /// <param name="dto">The DTO containing energy activity details.</param>
        /// <returns>A success message or an error message.</returns>
        [HttpPost("energy")]
        public async Task<IActionResult> AddEnergyActivity([FromBody] EnergyActivityRequestDto dto)
        {
            try
            {
                await _activityService.AddEnergyActivityAsync(dto);
                return Ok("Energy activity added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new transport activity.
        /// </summary>
        /// <param name="dto">The DTO containing transport activity details.</param>
        /// <returns>A success message or an error message.</returns>
        [HttpPost("transport")]
        public async Task<IActionResult> AddTransportActivity([FromBody] TransportActivityRequestDto dto)
        {
            try
            {
                await _activityService.AddTransportActivityAsync(dto);
                return Ok("Transport activity added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all activities.
        /// </summary>
        /// <returns>A list of all activities or an error message.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivities()
        {
            try
            {
                var activities = await _activityService.GetAllAsync();
                return Ok(activities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Retrieves a specific activity by ID.
        /// </summary>
        /// <param name="id">The ID of the activity.</param>
        /// <returns>The requested activity or an error message.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityByIdAsync(id);
                return Ok(activity);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific activity by ID.
        /// </summary>
        /// <param name="id">The ID of the activity to delete.</param>
        /// <returns>A success message or an error message.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            try
            {
                await _activityService.DeleteActivityAsync(id);
                return Ok("Activity deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
