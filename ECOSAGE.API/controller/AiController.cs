using ECOSAGE.SERVICE.ai;
using Microsoft.AspNetCore.Mvc;

namespace ECOSAGE.API.controller
{
    [Route("ecosage/[controller]")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly AiService _aiService;

        public AiController(AiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("message")]
        public async Task<IActionResult> SendMessageToAi([FromBody] string userMessage)
        {
            if (string.IsNullOrEmpty(userMessage))
            {
                return BadRequest("Message cannot be empty.");
            }

            try
            {
                var response = await _aiService.SendMessageToAiAsync(userMessage);

                if (string.IsNullOrEmpty(response))
                {
                    return NotFound("AI response not found.");
                }

                return Ok(new { Response = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
