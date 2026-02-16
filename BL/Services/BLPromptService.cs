using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Dal.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLPromptService : IBLPrompt
    {
        private readonly IPrompt _promptRepo;
        private readonly IBLAI _aiService;


        public BLPromptService(IPrompt promptRepo, IBLAI aiService)
        {
            _promptRepo = promptRepo;
            _aiService = aiService;
        }
        public async Task<List<Prompts>> GetPromptsByUserIdAsync(ObjectId userId)
        {
            var all = await _promptRepo.Read();
            return all.Where(p => p.UserId == userId).ToList();
        }


        public async Task Update(Prompts prompt)
        {
            await _promptRepo.UpDate(prompt);
        }
        public async Task CreateResponse(PromptRequest promptRequest)
        {
            // שולחים ל-AI
            string response = await _aiService.GetResponseFromAI(promptRequest.Prompt);

            // בונים אובייקט Prompts עם ה-Response שהתקבל מה-AI
            var prompt = new Prompts
            {
                UserId = ObjectId.Parse(promptRequest.UserId),
                SubCategoryId = promptRequest.SubCategoryId,
                Prompt = promptRequest.Prompt,
                Response = response,
                CreatedAt = DateTime.UtcNow
            };


            // שומרים את התשובה בבסיס הנתונים
            await _promptRepo.Create(prompt);
        }


    }
}

