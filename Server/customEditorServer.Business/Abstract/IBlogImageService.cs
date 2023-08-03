using customEditorServer.Entity.Concreate;
using Microsoft.AspNetCore.Http;

namespace customEditorServer.Business.Abstract;

public interface IBlogImageService
{
    List<Image> GetAll();
    Image GetById(int id);
    Image GetByImageUrl(string imageName);

    void Upload(List<IFormFile> files, string folderName, string fileName);
    void AddDatabase(Image image);
    void Delete(string folder, int imageId);
    void Update(IFormFile file, string folder, int id);
}

