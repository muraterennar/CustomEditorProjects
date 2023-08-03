using customEditorServer.Business.Abstract;
using customEditorServer.Core.DTO;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.Entity.Concreate;

namespace customEditorServer.Business.Concreate;

public class BlogManager : IBlogService
{
    readonly IBlogDal _blogDal;

    public BlogManager(IBlogDal blogDal)
    {
        _blogDal = blogDal;
    }

    public List<Blog> GetAll()
    {
        return _blogDal.GetAll();
    }

    public Blog GetByCategoryId(int categoryId)
    {
        return _blogDal.Get(b => b.BlogCategoryId == categoryId);
    }

    public Blog GetById(int id)
    {
        return _blogDal.GetById(id);
    }

    public void Add(Blog blog)
    {
        _blogDal.Add(blog);
    }

    public void Delete(Blog blog)
    {
        _blogDal.DeleteByEntity(blog);
    }

    public void Update(Blog blog)
    {
        _blogDal.Update(blog);
    }

    #region BlogDetailDto Operations
    public List<BlogDetailsDto> GetAllByDto()
    {
        return _blogDal.GetAllByDto();
    }

    public BlogDetailsDto BlogDetailDtoById(int id)
    {
        return _blogDal.GetByIdForDto(id);
    }

    public BlogDetailsDto BlogDetailDtoByBlogName(string blogTitle)
    {
        return _blogDal.GetByBlogNameForDto(blogTitle);
    }
    #endregion
}

