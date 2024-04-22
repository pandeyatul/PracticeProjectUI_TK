using ConcertBooking_Repository.Concert_Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Repo_implementation
{
    public class UtilityRepository : IUtility
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContext;

        public UtilityRepository(IWebHostEnvironment env, IHttpContextAccessor httpContext)
        {
            this.env = env;
            this.httpContext = httpContext;
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename=Path.GetFileName(dbPath);
            var completepath = Path.Combine(env.WebRootPath,ContainerName,filename);
            if (File.Exists(completepath))
            {
                File.Delete(completepath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string? dbPath)
        {
            await DeleteImage(ContainerName,dbPath);
           return await SaveImage(ContainerName,file);
        }

        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{fileExtension}";
            var folderepath = Path.Combine(env.WebRootPath, ContainerName);
            if (!Directory.Exists(folderepath))
            {
                Directory.CreateDirectory(folderepath);
            }
            var filepath = Path.Combine(folderepath, filename);
            using (var memmorystream = new MemoryStream())
            {
                await file.CopyToAsync(memmorystream);
                var filecontent = memmorystream.ToArray();
                await File.WriteAllBytesAsync(filepath, filecontent);
            }
            var basepath = $"{httpContext?.HttpContext?.Request.Scheme}://{httpContext?.HttpContext?.Request.Host}";
            var completepath = Path.Combine(basepath, ContainerName, filename).Replace("\\", "/");
            return completepath;
        }
    }
}
