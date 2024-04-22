using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface IUtility
    {
        Task<string> SaveImage(string containerName,IFormFile formFile);
        Task<string> EditImage(string containername,IFormFile file,string dbPath);
        Task DeleteImage(string containername, string dbPath);
    }
}
