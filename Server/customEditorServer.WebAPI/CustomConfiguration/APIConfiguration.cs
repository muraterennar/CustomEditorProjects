using customEditorServer.Business.Abstract;
using customEditorServer.Business.Concreate;
using customEditorServer.Core.Helpers.FileHelper;
using customEditorServer.DataAccess.Abstract;
using customEditorServer.DataAccess.Concreate;
using customEditorServer.DataAccess.Contexts;

namespace customEditorServer.WebAPI.CustomConfiguration;

public static class APIConfiguration
{
    public static void Load(this IServiceCollection services)
    {
        services.AddSingleton<MsSqlDbContext>();

        services.AddSingleton<IBlogDal, BlogDal>();
        services.AddSingleton<IBlogService, BlogManager>();

        services.AddSingleton<IBlogCategoryDal, BlogCategoryDal>();
        services.AddSingleton<IBlogCategoryService, BlogCategoryManager>();

        services.AddSingleton<IBlogImageDal, BlogImageDal>();
        services.AddSingleton<IBlogImageService, BlogImageManager>();
        services.AddSingleton<IFileHelper, FileHelperManager>();
    }
}

