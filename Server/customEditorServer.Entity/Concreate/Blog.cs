using customEditorServer.Core.Entites;

namespace customEditorServer.Entity.Concreate;

public class Blog : IEntity
{
    public int Id { get; set; }
    public string BlogTitle { get; set; }
    public int BlogCategoryId { get; set; }
    public string BlogDescription { get; set; }
    public bool BlogPreview { get; set; }
}

