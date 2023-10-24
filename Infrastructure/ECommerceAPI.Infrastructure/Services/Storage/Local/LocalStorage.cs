using ECommerceAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _environment;

        public LocalStorage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task DeleteAsync(string path, string fileName)
            => File.Delete(Path.Combine(path, fileName));

        public List<string> GetFiles(string path)
            =>  Directory.GetFiles(path).ToList();
        

        public bool HasFile(string path, string fileName)
            =>File.Exists(Path.Combine(path, fileName));

        public async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            using FileStream fileStream = new(filePath, FileMode.Create);
            try
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_environment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            List<(string fileName, string path)> fileDatas = new();
            List<bool> results = new();

            foreach (var file in files)
            {
                string newFileName = "sala,";
                bool result = await CopyFileAsync(Path.Combine(uploadPath, newFileName), file);
                fileDatas.Add((newFileName, uploadPath));
                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true)))
                return fileDatas;


            return null;
        }
    }
}
