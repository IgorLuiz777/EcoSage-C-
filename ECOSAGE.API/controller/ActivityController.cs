using ECOSAGE.DATA.models.activity;
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

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivities()
        {
            try
            {
                var activities = await _activityService.GetAllActivitiesAsync();
                return Ok(activities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityByIdAsync(id);
                if (activity == null)
                {
                    return NotFound("Activity not found");
                }

                return Ok(activity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity([FromBody] Activity activity)
        {
            try
            {
                await _activityService.AddActivityAsync(activity);
                return CreatedAtAction(nameof(GetActivityById), new { id = activity.ActivityId }, activity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            try
            {
                if (id != activity.ActivityId)
                {
                    return BadRequest("Activity ID mismatch.");
                }

                await _activityService.UpdateActivityAsync(activity);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            try
            {
                await _activityService.DeleteActivityAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
