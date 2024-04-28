namespace AlexanderNevskyTemple.WebAPI.dto;
public class ArticleDto {
    public long Id { get; set; }
    public CatalogDto Catalog { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
}