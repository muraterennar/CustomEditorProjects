using customEditorServer.Business.Abstract;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.Entity.Concreate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace customEditorServer.Business.Concreate;

public class BlogImageManager : IBlogImageService
{
    private readonly IBlogImageDal _imageDal;
    private readonly IFileHelper _fileHelper;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly IConfiguration _configuration;

    public BlogImageManager(IBlogImageDal imageDal, IFileHelper fileHelper, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
    {
        _imageDal = imageDal;
        _fileHelper = fileHelper;
        _hostingEnvironment = hostingEnvironment;
        _configuration = configuration;
    }

    public List<Image> GetAll()
    {
        return _imageDal.GetAll();
    }

    public Image GetById(int id)
    {
        return _imageDal.GetById(id);
    }

    public Image GetByImageUrl(string imageName)
    {
        var image = _imageDal.Get(i => i.ImageName == imageName);

        //return new Image
        //{
        //    Id = image.Id,
        //    ImageUrl = $"{_configuration["ImageBaseUrl"]}project-img/{image.ImageUrl}",
        //    ImageName = image.ImageName
        //};

        return new Image
        {
            Id = image.Id,
            ImageUrl = image.ImageUrl,
            ImageName = image.ImageName
        };
    }

    public void Delete(string folder, int imageId)
    {
        Image image = _imageDal.GetById(imageId);
        _fileHelper.Delete(folder, image.ImageUrl);
        _imageDal.DeleteByEntity(image);
    }

    public void Update(IFormFile file, string folder, int id)
    {
        Image image = _imageDal.GetById(id);
        string oldPath = image.ImageUrl;

        image.ImageUrl = _fileHelper.Update(file, folder, oldPath);

        _imageDal.Update(image);
    }

    public void Upload(List<IFormFile> files, string folderName, string fileName)
    {
        foreach (IFormFile file in files)
        {
            string imagePath = _fileHelper.Upload(file, folderName);
            _imageDal.Add(new Image
            {
                ImageName = fileName,
                ImageUrl = imagePath
            });
        }
    }

    public void AddDatabase(Image image)
    {
        _imageDal.Add(image);
    }
}

