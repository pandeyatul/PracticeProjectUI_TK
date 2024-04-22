using Entities_TK.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_Repository
{
    public class UtilityRepository : IUtility
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor contextAccessor;

        public UtilityRepository(IHttpContextAccessor contextAccessor, IWebHostEnvironment webHost)
        {
            this.contextAccessor = contextAccessor;
            this._env = webHost;
        }

        public Task DeleteImage(string containername, string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completefilepath = Path.Combine(_env.WebRootPath, containername, filename);
            if (File.Exists(completefilepath))
            {   
                File.Delete(completefilepath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string containername, IFormFile file, string dbPath)
        {
            await DeleteImage(containername,dbPath);
            return await SaveImage(containername,file);
        }

        public async Task<string> SaveImage(string containerName, IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            var filename = $"{Guid.NewGuid()}{fileExtension}";
            var folderepath = Path.Combine(_env.WebRootPath, containerName);
            if (!Directory.Exists(folderepath))
            {
                Directory.CreateDirectory(folderepath);
            }
            var filepath = Path.Combine(folderepath, filename);
            using (var memmorystream = new MemoryStream())
            {
                await formFile.CopyToAsync(memmorystream);
                var filecontent = memmorystream.ToArray();
                await File.WriteAllBytesAsync(filepath, filecontent);
            }
            var basepath=$"{contextAccessor?.HttpContext?.Request.Scheme}://{contextAccessor?.HttpContext?.Request.Host}";
            var completepath=Path.Combine(basepath, containerName,filename).Replace("\\","/");
            return completepath;
        }
    }
}
