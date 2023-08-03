using Microsoft.AspNetCore.Http;


public interface IFileHelper
{
    public string Upload(IFormFile file, string folderName);
    public string Update(IFormFile file, string folder, string oldFile);
    public void Delete(string folder, string filePath);
}

