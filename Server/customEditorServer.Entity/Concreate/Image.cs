using customEditorServer.Core.Entites;

namespace customEditorServer.Entity.Concreate;

public class Image : IEntity
{
    public int Id { get; set; }
    public string ImageName { get; set; }
    public string ImageUrl { get; set; }
}
