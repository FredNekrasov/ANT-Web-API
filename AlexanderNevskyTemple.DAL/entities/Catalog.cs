using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL.entities;

[PrimaryKey(nameof(Id))]
public class Catalog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Article> Articles { get; set; }
}