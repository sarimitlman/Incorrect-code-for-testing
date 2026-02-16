using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLCategory
    {
       
        public Task<Categories> GetCategoryByIdAsync(string id);
        public Task<List<Categories>> GetAll();

    }
}
