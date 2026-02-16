using BL.Api;
using Microsoft.AspNetCore.Mvc;

namespace Servere.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AIController : Controller
    {
        private readonly IBLAI _aiService;
        public AIController(IBLAI aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("prompt")]
        public async Task<IActionResult> SendPrompt([FromBody] string prompt)
        {
            var response = await _aiService.GetResponseFromAI(prompt);
            return Ok(response);
        }
    }
}
