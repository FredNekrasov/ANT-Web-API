namespace AlexanderNevskyTemple.BLL.models; 
public class ArticleModel {
    public long Id { get; set; }
    public CatalogModel Catalog { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateOrBanner { get; set; } = string.Empty;
}