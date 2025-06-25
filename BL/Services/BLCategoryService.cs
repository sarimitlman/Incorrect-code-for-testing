using BL.Api;
using Dal.Api;
using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BL.Services
{
   

    namespace BL.Services
    {
        public class BLCategoryService : IBLCategory
        {
            private readonly ICategory categoryRepository;

            public BLCategoryService(ICategory categoryRepository)
            {
                this.categoryRepository = categoryRepository;
            }

          
            // GetCategoryById: קבלת קטגוריה לפי ID
            public async Task<Categories> GetCategoryByIdAsync(string id)
            {
                var categories = await categoryRepository.Read();
                var category = categories.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    throw new Exception($"Category with ID {id} not found.");
                }

                return category;
            }

            // GetAll: קבלת כל הקטגוריות
            public async Task<List<Categories>> GetAll()
            {
                return await categoryRepository.Read();
            }   
        }
    }

}
