using customEditorServer.Core.DataAccess.EntityFramework;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.DataAccess.Contexts;
using customEditorServer.Entity.Concreate;

namespace customEditorServer.DataAccess.Concreate;

public class BlogImageDal : EfEntityRepositorybase<Image, MsSqlDbContext>, IBlogImageDal
{
}

