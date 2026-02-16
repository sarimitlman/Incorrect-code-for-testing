using BL.Api;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IBLCategory _blCategory;

    public CategoriesController(IBLCategory blCategory)
    {
        _blCategory = blCategory;
    }

    // GET api/category
    [HttpGet]
    public async Task<ActionResult<List<Categories>>> GetAllCategories()
    {
        var categories = await _blCategory.GetAll();
        return Ok(categories);
    }

    // GET api/category/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Categories>> GetCategoryById(string id)
    {
        // לא צריך להמיר ל-ObjectId אם ה-id שלך הוא מסוג string
        var category = await _blCategory.GetCategoryByIdAsync(id);  // מתודה המקבלת string ולא ObjectId
        if (category == null)
            return NotFound();

        return Ok(category);
    }
}
