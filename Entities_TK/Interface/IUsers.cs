using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface IUsers
    {
        Task RegisterUser(Users users);
        Task<Users> GetUser(string username,string password);
        Task<string> RegisterTaxpayer(Taxpayer users);
        Task UpdateRegisterTaxpayer(Taxpayer users);
        Task<List<Taxpayer>> GetTaxpayerInfo();
        Task<Taxpayer> GetTaxpayerInfoById(int id);
    }
}
