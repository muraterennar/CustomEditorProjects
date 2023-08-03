using customEditorServer.Entity.Concreate;
using Microsoft.EntityFrameworkCore;

namespace customEditorServer.DataAccess.Contexts;

public class MsSqlDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("connectionstring");
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<Image> Images { get; set; }
}

