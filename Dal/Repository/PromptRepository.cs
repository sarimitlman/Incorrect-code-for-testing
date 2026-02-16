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
    public class PromptRepository : IPrompt
    {
        private readonly IMongoCollection<Prompts> _collection;

        public PromptRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AiLearningDb");
            _collection = database.GetCollection<Prompts>("Prompts");
        }

        // Create: הוספת פרומפט חדש
        public async Task Create(Prompts item)
        {
            await _collection.InsertOneAsync(item);
        }

        // Delete: מחיקת פרומפט על פי ID
        public async Task Delete(Prompts item)
        {
            var filter = Builders<Prompts>.Filter.Eq(p => p.Id, item.Id);
            await _collection.DeleteOneAsync(filter);
        }

        // Read: קריאה של כל הפרומפטים
        public async Task<List<Prompts>> Read()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Update: עדכון פרומפט על פי ID
        public async Task UpDate(Prompts item)
        {
            var filter = Builders<Prompts>.Filter.Eq(p => p.Id, item.Id);
            var update = Builders<Prompts>.Update
                .Set(p => p.Prompt, item.Prompt) // לדוגמה, לעדכן את תוכן הפרומפט
                .Set(p => p.Response, item.Response); // לעדכן את התשובה
            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
