using customEditorServer.Business.Abstract;
using customEditorServer.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace customEditorServer.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogCategoriesController : Controller
{
    readonly IBlogCategoryService _blogService;

    public BlogCategoriesController(IBlogCategoryService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _blogService.GetAll();
        return result != null ? Ok(result) : BadRequest("Hata !");
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _blogService.GetById(id);
        return result != null ? Ok(result) : BadRequest("Hata !");
    }

    [HttpGet("getbyname/{name}")]
    public IActionResult GetByName(string name)
    {
        var result = _blogService.GetByName(name);
        return result != null ? Ok(result) : BadRequest("Hata !");
    }

    [HttpPost]
    public IActionResult Add(BlogCategory blogCategory)
    {
        _blogService.Add(blogCategory);
        return Ok();
    }

    [HttpPatch]
    public IActionResult Update(BlogCategory blogCategory)
    {
        _blogService.Update(blogCategory);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteById(int id)
    {
        _blogService.DeleteById(id);
        return Ok();
    }

    [HttpDelete("delete/{name}")]
    public IActionResult DeleteByName(BlogCategory blogCategory)
    {
        _blogService.Delete(blogCategory);
        return Ok();
    }
}

