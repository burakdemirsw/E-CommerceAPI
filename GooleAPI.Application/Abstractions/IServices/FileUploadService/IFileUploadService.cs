using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooleAPI.Application.Abstractions.IServices.FileUploadService
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync();
        Task<List<string>> GetPhotoUrlsInFolder(string folderId);
        Task<string> UploadFileAsync2(IFormFile file);
        Task<List<string>> UploadFileAsync3(List<IFormFile> files);
    }
}
