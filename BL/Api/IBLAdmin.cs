
using BL.Dtos;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLAdmin
    {
        Task<List<UserWithPromptsDto>> GetUsersWithPromptsAsync();
    }
}
