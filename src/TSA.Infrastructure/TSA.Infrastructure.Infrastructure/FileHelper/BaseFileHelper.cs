using Microsoft.AspNetCore.Http;

namespace TSA.Infrastructure.Infrastructure.FileHelper;

public abstract class BaseFileHelper
{
    public abstract void DeleteFile(string path);
    public abstract Task<string> SaveFileAsync(IFormFile file);
}