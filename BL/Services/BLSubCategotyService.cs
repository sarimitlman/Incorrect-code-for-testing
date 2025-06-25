using BL.Api;
using Dal.Api;
using Dal.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLSubCategoryService : IBLSubCategory
    {
        private readonly ISubCategory _subCategoryRepository;
        private readonly ICategory _categoryRepository;

        public BLSubCategoryService(ISubCategory subCategoryRepository, ICategory categoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<SubCategory>> GetCategoryByNameAsync(string categoryName)
        {
            // קבל את כל הקטגוריות
            var categories = await _categoryRepository.Read();
            // מצא את הקטגוריה לפי שם
            var category = categories.FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                throw new Exception($"Category with name {categoryName} not found.");
            }

            // קבל את כל תתי-הקטגוריות וסנן לפי מזהה הקטגוריה
            var allSubCategories = await _subCategoryRepository.Read();
            var subCategories = allSubCategories
                .Where(sc => sc.CategoryId == category.Id.ToString())
                .ToList();

            return subCategories;
        }

        // מימוש נכון של המתודה מהאינטרפייס
        public async Task<List<SubCategory>> GetSubCategoriesByCategoryIdAsync(string categoryId)
        {
            var allSubCategories = await _subCategoryRepository.Read();
            var subCategories = allSubCategories
                .Where(sc => sc.CategoryId == categoryId.ToString())
                .ToList();

            return subCategories;
        }
    }
}
