using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBLUser _blUserService;

        public UserController(IBLUser blUserService)
        {
            _blUserService = blUserService;
        }

        // POST api/users
        [HttpPost]
        public ActionResult Create(Users user)
        {
            _blUserService.Create(user);
            return Ok();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserByIdAsync(string id)
        {
            var user = await _blUserService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAll()
        {
            var users = await _blUserService.GetAll();
            return Ok(users);
        }


    }
}
