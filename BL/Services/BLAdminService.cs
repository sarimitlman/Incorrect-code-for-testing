using BL.Api;
using BL.Dtos;
using Dal.Api;
using Dal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLAdminService : IBLAdmin
    {
        private readonly IUsers _userRepository;
        private readonly IPrompt _promptRepository;

        public BLAdminService(IUsers userRepository, IPrompt promptRepository)
        {
            _userRepository = userRepository;
            _promptRepository = promptRepository;
        }

        public async Task<List<UserWithPromptsDto>> GetUsersWithPromptsAsync()
        {
            var users = await _userRepository.Read();
            var prompts = await _promptRepository.Read();

            var result = users.Select(user => new UserWithPromptsDto
            {
                Id = user.Id, // ObjectId is directly assigned as the DTO expects ObjectId
                Name = user.Name,
                Phone = user.Phone,
                Prompts = prompts
                   .Where(p => p.UserId.ToString() == user.Id) 
                    .ToList()
            }).ToList();

            return result;
        }
    }
}
