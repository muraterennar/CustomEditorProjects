using customEditorServer.Core.DataAccess.EntityFramework;
using customEditorServer.Core.DTO;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.DataAccess.Contexts;
using customEditorServer.Entity.Concreate;
using Microsoft.EntityFrameworkCore;

namespace customEditorServer.DataAccess.Concreate;

public class BlogDal : EfEntityRepositorybase<Blog, MsSqlDbContext>, IBlogDal
{
    public List<BlogDetailsDto> GetAllByDto()
    {
        using (MsSqlDbContext context = new MsSqlDbContext())
        {
            var result = from blog in context.Blogs
                         join blogCategory in context.BlogCategories on blog.BlogCategoryId equals blogCategory.Id
                         select new BlogDetailsDto
                         {
                             Id = blog.Id,
                             BlogTitle = blog.BlogTitle,
                             CategoryName = blogCategory.CategoryName,
                             BlogDescription = blog.BlogDescription
                         };
            return result.ToList();
        }
    }

    public List<BlogDetailsDto> GetListByIdForDto(int id)
    {
        return GetAllByDto().Where(x => x.Id == id).ToList();
    }

    public BlogDetailsDto GetByIdForDto(int id)
    {
        return GetAllByDto().SingleOrDefault(x => x.Id == id);
    }

    public BlogDetailsDto GetByBlogNameForDto(string blogTitle)
    {
        return GetAllByDto().SingleOrDefault(x => x.BlogTitle == blogTitle);
    }
}

