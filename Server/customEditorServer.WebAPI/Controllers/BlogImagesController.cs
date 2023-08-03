using customEditorServer.Business.Abstract;
using customEditorServer.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace customEditorServer.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogImagesController : Controller
{
    private readonly IBlogImageService _imageService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;

    public BlogImagesController(IBlogImageService imageService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        _imageService = imageService;
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _imageService.GetAll();
        return result != null ? Ok(result) : BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _imageService.GetById(id);

        return result != null ? Ok(result) : BadRequest(error: "Hata");
    }


    [HttpGet("[action]/{imageName}")]
    public IActionResult GetByImagePath(string imageName)
    {
        var result = _imageService.GetByImageUrl(imageName);
        return result != null ? Ok(result) : BadRequest(error: "Hata");
    }


    [HttpPost("[action]/{fileName}")]
    public IActionResult Upload(string fileName)
    {
        var folderName = _configuration["ImageSaveFolder"];

        _imageService.Upload((List<IFormFile>?)Request.Form.Files, folderName, fileName);
        return Ok();
    }

    [HttpPost("[action]")]
    public IActionResult AddDatabase(Image image)
    {
        _imageService.AddDatabase(image);

        return Ok(image);
    }

    [HttpDelete]
    public IActionResult Delete(int imageId, string folder)
    {
        _imageService.Delete(folder, imageId);
        return Ok();

    }

    [HttpPut]
    public IActionResult Update(IFormFile file, int id, string folder)
    {
        _imageService.Update(file, folder, id);
        return Ok();
    }
}


