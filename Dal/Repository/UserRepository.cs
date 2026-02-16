using Dal.Api;
using Dal.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class UserRepository : IUsers
    {
        private readonly IMongoCollection<Users> _collection;

        public UserRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("AiLearningDb");
            _collection = database.GetCollection<Users>("Users");
        }

        // Create: מוסיף משתמש חדש
        public async Task Create(Users item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            await _collection.InsertOneAsync(item); // מכניס את המשתמש לבסיס הנתונים
        }

        // Delete: מוחק משתמש לפי ה-Id שלו
        public async Task Delete(Users item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<Users>.Filter.Eq(u => u.Id, item.Id);
            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new Exception($"User with ID {item.Id} not found.");
            }
        }

        // Read: מחזיר את כל המשתמשים
        public async Task<List<Users>> Read()
        {
            return await _collection.Find(_ => true).ToListAsync(); // מחזיר את כל המשתמשים
        }

        // Update: מעדכן את פרטי המשתמש
        public async Task UpDate(Users item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var filter = Builders<Users>.Filter.Eq(u => u.Id, item.Id);
            var update = Builders<Users>.Update
                .Set(u => u.Name, item.Name)
                .Set(u => u.Phone, item.Phone);

            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                throw new Exception($"User with ID {item.Id} not found or not updated.");
            }
        }
        public async Task<Users> FindByPhoneAsync(string phone)
        {
            return await _collection.Find(u => u.Phone == phone).FirstOrDefaultAsync();
        }
    }
}
