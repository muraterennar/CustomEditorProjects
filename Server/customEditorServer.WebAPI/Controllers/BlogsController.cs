using customEditorServer.Business.Abstract;
using customEditorServer.Core.DTO;
using customEditorServer.Entity.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace customEditorServer.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController : Controller
{
    readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        List<Blog> blogs = _blogService.GetAll();
        return blogs != null ? Ok(blogs) : BadRequest();
    }

    [HttpGet("getllbtdto")]
    public IActionResult GetAllByDto()
    {
        List<BlogDetailsDto> blogs = _blogService.GetAllByDto();
        return blogs != null ? Ok(blogs) : BadRequest();
    }

    //[HttpGet("getbyid/{id}")]
    //public IActionResult GetById(int id)
    //{
    //    Blog blog = _blogService.GetById(id);
    //    return blog != null ? Ok(blog) : BadRequest("Hata!");
    //}

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById(int id)
    {
        BlogDetailsDto blog = _blogService.BlogDetailDtoById(id);
        return blog != null ? Ok(blog) : BadRequest("Hata!");
    }

    [HttpGet("getbycategoryid/{id}")]
    public IActionResult GetByCategoryName(int id)
    {
        Blog blog = _blogService.GetByCategoryId(id);
        return blog != null ? Ok(blog) : BadRequest("Hata!");
    }

    [HttpGet("getbyblogtitle/{blogTitle}")]
    public IActionResult GetByBlogTitle(string blogTitle)
    {
        BlogDetailsDto blog = _blogService.BlogDetailDtoByBlogName(blogTitle);
        return blog != null ? Ok(blog) : BadRequest("Hata!");
    }

    [HttpPost("add")]
    public IActionResult Add(Blog blog)
    {
        _blogService.Add(blog);
        return Ok();
    }

    [HttpPatch("update")]
    public IActionResult Update(Blog blog)
    {
        _blogService.Update(blog);
        return Ok();
    }

    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var blog = _blogService.GetById(id);
        _blogService.Delete(blog);
        return Ok();
    }
}

