using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.entities;

[PrimaryKey(nameof(Id))]
public class Content {
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public string Data { get; set; } = string.Empty;//it can be contacts or images
    public virtual Article Article { get; set; }
}