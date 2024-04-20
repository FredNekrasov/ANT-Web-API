using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.entities;

[PrimaryKey(nameof(Id))]
public class Article {
    public long Id { get; set; }
    public int CatalogId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public virtual Catalog Catalog { get; set; }
    public virtual ICollection<Content> Contents { get; set; }
}