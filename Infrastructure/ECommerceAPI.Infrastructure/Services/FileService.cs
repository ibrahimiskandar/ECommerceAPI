using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    public static class FileService 
    {
        public static string GenerateFileNameAsync(IFormFile file)
        {
            return $"{Guid.NewGuid()}{file.FileName}";
        }

        
    }
}
