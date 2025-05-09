﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagementBLL.Services
{
    public interface IUtility
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file, string? dbPath);
        Task DeleteImage(string ContainerName, string dbPath);
    }
}
