using Dal.Api;
using Dal.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly IMongoCollection<Categories> _collection;

        public CategoryRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AiLearningDb");
            _collection = database.GetCollection<Categories>("categories");
        }

        // Create: מוסיף קטגוריה חדשה
        public async Task Create(Categories item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _collection.InsertOneAsync(item); // מכניס את הקטגוריה לבסיס הנתונים
        }

        // Delete: מוחק קטגוריה לפי ה-Id שלה
        public async Task Delete(Categories item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<Categories>.Filter.Eq(c => c.Id, item.Id);
            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new Exception($"Category with ID {item.Id} not found.");
            }
        }

        // Read: מחזיר את כל הקטגוריות
        public async Task<List<Categories>> Read()
        {
            return await _collection.Find(_ => true).ToListAsync(); // מחזיר את כל הקטגוריות
        }

        // Update: מעדכן קטגוריה
        public async Task UpDate(Categories item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<Categories>.Filter.Eq(c => c.Id, item.Id);
            var update = Builders<Categories>.Update
                .Set(c => c.Name, item.Name); // עדכון שם הקטגוריה

            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                throw new Exception($"Category with ID {item.Id} not found or not updated.");
            }
        }
    }
}
