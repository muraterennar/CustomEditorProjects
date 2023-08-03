using customEditorServer.Business.Abstract;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.Entity.Concreate;

namespace customEditorServer.Business.Concreate;

public class BlogCategoryManager : IBlogCategoryService
{
    private readonly IBlogCategoryDal _blogCategoryDal;

    public BlogCategoryManager(IBlogCategoryDal blogCategoryDal)
    {
        _blogCategoryDal = blogCategoryDal;
    }

    public List<BlogCategory> GetAll()
    {
        return _blogCategoryDal.GetAll();
    }

    public BlogCategory GetById(int id)
    {
        return _blogCategoryDal.GetById(id);
    }

    public BlogCategory GetByName(string name)
    {
        return _blogCategoryDal.Get(b => b.CategoryName == name);
    }

    public void Add(BlogCategory category)
    {
        _blogCategoryDal.Add(category);
    }

    public void Delete(BlogCategory category)
    {
        _blogCategoryDal.DeleteByEntity(category);
    }

    public void DeleteById(int id)
    {
        _blogCategoryDal.DeleteById(id);
    }

    public void Update(BlogCategory category)
    {
        _blogCategoryDal.Update(category);
    }

}

