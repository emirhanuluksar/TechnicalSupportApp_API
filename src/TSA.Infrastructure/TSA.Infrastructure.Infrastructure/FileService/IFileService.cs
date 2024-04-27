using Microsoft.AspNetCore.Http;

namespace TSA.Infrastructure.Infrastructure.FileService;

public interface IFileService
{
    Task<string> SaveFileAsync(Guid companyId, IFormFile file, string path);
    void DeleteFile(string path);
}