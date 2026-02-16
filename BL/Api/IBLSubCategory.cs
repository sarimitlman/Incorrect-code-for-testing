using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{


    public interface IBLSubCategory
    {
        Task<List<SubCategory>> GetCategoryByNameAsync(string categoryName);
    }

}
