using Dal.Api;
using Dal.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class SubCategoryRepository : ISubCategory
    {
        private readonly IMongoCollection<SubCategory> _collection;

        public SubCategoryRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AiLearningDb");
            _collection = database.GetCollection<SubCategory>("SubCategories"); 
        }

        // Create: מוסיף תת-קטגוריה חדשה
        public async Task Create(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _collection.InsertOneAsync(item);
        }

        // Delete: מוחק תת-קטגוריה
        public async Task Delete(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var filter = Builders<SubCategory>.Filter.Eq(sc => sc.Id, item.Id);
            var result = await _collection.DeleteOneAsync(filter);
            if (result.DeletedCount == 0)
            {
                throw new Exception($"SubCategory with ID {item.Id} not found.");
            }
        }

        // Read: מחזיר את כל תתי-הקטגוריות
        public async Task<List<SubCategory>> Read()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Update: מעדכן תת-קטגוריה
        public async Task UpDate(SubCategory item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var filter = Builders<SubCategory>.Filter.Eq(sc => sc.Id, item.Id);
            var update = Builders<SubCategory>.Update.Set(sc => sc.Name, item.Name);
            var result = await _collection.UpdateOneAsync(filter, update);
            if (result.ModifiedCount == 0)
            {
                throw new Exception($"SubCategory with ID {item.Id} not found or not updated.");
            }
        }


    }
}
