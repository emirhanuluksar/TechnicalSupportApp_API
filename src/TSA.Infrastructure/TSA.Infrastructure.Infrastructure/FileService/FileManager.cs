using Microsoft.AspNetCore.Http;

namespace TSA.Infrastructure.Infrastructure.FileService;

public class FileManager : IFileService
{
    public async Task<string> SaveFileAsync(Guid companyId, IFormFile file, string path)
    {
        ValidateFile(file);

        var fileName = GenerateFileName(companyId, file);
        var filePath = Path.Combine(path, fileName);

        if (!FileExists(filePath))
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        return filePath;
    }

    private bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }


    private void ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Invalid file");
        }
    }

    private string GenerateFileName(Guid companyId, IFormFile file)
    {
        return companyId.ToString() + Path.GetExtension(file.FileName);
    }

    public void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}