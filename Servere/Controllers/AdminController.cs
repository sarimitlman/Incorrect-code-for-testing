using BL.Api;
using BL.Dtos;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBLAdmin _adminService;

        public AdminController(IBLAdmin adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserWithPromptsDto>>> GetUsersWithPrompts()
        {
            var result = await _adminService.GetUsersWithPromptsAsync();
            return Ok(result);
        }
    }
}
