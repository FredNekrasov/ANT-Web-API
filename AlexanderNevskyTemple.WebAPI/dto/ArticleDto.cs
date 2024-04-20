using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.WebAPI.dto; 
public class ArticleDto {
    public long Id { get; set; }
    public Catalog Catalog { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}