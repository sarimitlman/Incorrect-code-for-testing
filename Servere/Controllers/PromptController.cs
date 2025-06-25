using BL;
using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        private readonly IBLPrompt _promptService;

        public PromptController(IBLPrompt promptService)
        {
            _promptService = promptService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prompts>>> GetByUserId([FromQuery] string userId)
        {
            if (!ObjectId.TryParse(userId, out ObjectId userObjectId))
                return BadRequest("Invalid userId");

            var result = await _promptService.GetPromptsByUserIdAsync(userObjectId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrompt([FromBody] PromptDto dto)
        {
            // כאן תשלב את הקריאה ל-AI, שמירה ב-DB והחזרת תשובה
            // לדוגמה:
            var aiResponse = "This is a mock AI response"; // כאן תשלב את OpenAI בעתיד
                                                           // שמור את הפרטים ב-DB אם צריך
            return Ok(new { response = aiResponse });
        }
    }


}


