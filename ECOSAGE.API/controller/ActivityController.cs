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
