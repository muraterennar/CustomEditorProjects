using customEditorServer.Core.Entites;

namespace customEditorServer.Entity.Concreate;

public class BlogCategory : IEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
}

