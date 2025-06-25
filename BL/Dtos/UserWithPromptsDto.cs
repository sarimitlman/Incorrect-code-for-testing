using Dal.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class UserWithPromptsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Prompts> Prompts { get; set; }
    }

}
