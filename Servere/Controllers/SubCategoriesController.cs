using BL.Api;
using BL.Services;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly IBLSubCategory _blSubCategory;

        public SubCategoriesController(IBLSubCategory blSubCategory)
        {
            _blSubCategory = blSubCategory;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetSubCategoriesByCategory([FromQuery] string categoryId)
        {
            try
            {
                if (!ObjectId.TryParse(categoryId, out ObjectId objectId))
                    return BadRequest("Invalid categoryId");

                var result = await _blSubCategory.GetSubCategoriesByCategoryIdAsync(objectId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
