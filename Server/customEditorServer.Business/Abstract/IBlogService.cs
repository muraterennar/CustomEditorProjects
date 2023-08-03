using customEditorServer.Core.DTO;
using customEditorServer.Entity.Concreate;

namespace customEditorServer.Business.Abstract;

public interface IBlogService
{
    List<Blog> GetAll();
    List<BlogDetailsDto> GetAllByDto();
    Blog GetById(int id);
    Blog GetByCategoryId(int categoryId);
    BlogDetailsDto BlogDetailDtoById(int id);
    BlogDetailsDto BlogDetailDtoByBlogName(string blogTitle);

    void Add(Blog blog);
    void Update(Blog blog);
    void Delete(Blog blog);
}

