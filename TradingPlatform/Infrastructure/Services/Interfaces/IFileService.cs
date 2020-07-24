using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Infrastructure.Services.Interfaces
{
    public interface IFileService
    {
        public string GenerateItemFileName(string fileName);

        public Task<string> UploadImageAsync(IFormFile item);
    }
}
