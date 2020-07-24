using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.Services.Interfaces;

namespace TradingPlatform.Infrastructure.Services.Implementations
{
    public class FileService : IFileService
    {
        public string ImagePath { get; set; }

        public IWebHostEnvironment _appEnvironment;

        public FileService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public string GenerateItemFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string newFileName = $@"{Guid.NewGuid()}{extension}";

            return newFileName;
        }

        public async Task<string> UploadImageAsync(IFormFile item)
        {
            if (item?.Length > 0)
            {
                string path = "/images/" + this.GenerateItemFileName(item.FileName);

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream);

                    return path;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
