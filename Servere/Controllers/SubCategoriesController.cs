using BL.Api;
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

        // GET api/category
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetSubCategoriesByCategory([FromQuery] string categoryName)
        {
            try
            {
                var result = await _blSubCategory.GetCategoryByNameAsync(categoryName);  // שולחים את שם הקטגוריה
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
