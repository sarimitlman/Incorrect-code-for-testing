using BL.Models;
using Dal.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLPrompt
    {
        Task CreateResponse(PromptRequest promptRequest);
        Task<List<Prompts>> GetPromptsByUserIdAsync(ObjectId userId);

    }
}

