using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLUser
    {
        Task<Users> GetUserByIdAsync(string id);
        Task<List<Users>> GetAll();
        Task<Users> FindByPhoneAsync(string phone); // הוסף שורה זו!
        Task Create(Users user); // ודא שיש גם את זה
    }
}
