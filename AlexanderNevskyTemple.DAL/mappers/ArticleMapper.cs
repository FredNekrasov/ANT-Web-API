using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.DAL.mappers; 
public static class ArticleMapper {
    public static Article ToEntity(this ArticleModel model) => new() {
        Id = model.Id,
        CatalogId = model.Catalog.Id,
        Title = model.Title,
        Description = model.Description,
        DateOrBanner = model.DateOrBanner
    };
}