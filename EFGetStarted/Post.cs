namespace EFGetStarted.Entity;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
}
