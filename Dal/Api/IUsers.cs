using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IUsers : ICrud<Users>
    {
        Task<Users> FindByPhoneAsync(string phone);
    }
}
