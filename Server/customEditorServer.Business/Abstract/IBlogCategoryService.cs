using customEditorServer.Entity.Concreate;

namespace customEditorServer.Business.Abstract;

public interface IBlogCategoryService
{
    List<BlogCategory> GetAll();
    BlogCategory GetById(int id);
    BlogCategory GetByName(string name);

    void Add(BlogCategory category);
    void Update(BlogCategory category);
    void Delete(BlogCategory category);
    void DeleteById(int id);
}

