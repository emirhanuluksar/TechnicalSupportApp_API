using Microsoft.AspNetCore.Http;

namespace TSA.Infrastructure.Infrastructure.FileHelper;

public class FileHelper : BaseFileHelper
{
    private readonly string _basePath;
    private readonly string _subPath;

    public FileHelper(string basePath, string subPath)
    {
        _basePath = basePath;
        _subPath = subPath;
    }

    public override void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public override async Task<string> SaveFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is null or empty.");

        string fileName = $"{Guid.NewGuid().ToString()}_{Path.GetFileName(file.FileName)}";
        string filePath = Path.Combine(_basePath, _subPath, fileName);

        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }
}
