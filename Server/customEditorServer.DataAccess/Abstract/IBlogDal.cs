using customEditorServer.Core.DataAccess;
using customEditorServer.Core.DTO;
using customEditorServer.Entity.Concreate;

namespace customEditorServer.DataAccess.Abstract;

public interface IBlogDal : IEntityRepository<Blog>
{
    List<BlogDetailsDto> GetAllByDto();
    List<BlogDetailsDto> GetListByIdForDto(int id);
    BlogDetailsDto GetByIdForDto(int id);
    BlogDetailsDto GetByBlogNameForDto(string blogTitle);
}

