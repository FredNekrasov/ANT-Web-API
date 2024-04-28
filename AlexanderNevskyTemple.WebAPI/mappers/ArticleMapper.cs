using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.WebAPI.dto;

namespace AlexanderNevskyTemple.WebAPI.mappers;
public static class ArticleMapper {
    public static ArticleDto ToDto(this Article entity) => new() {
        Id = entity.Id,
        Catalog = entity.Catalog.ToDto(),
        Title = entity.Title,
        Description = entity.Description,
        DateOrBanner = entity.DateOrBanner
    };
    public static Article ToEntity(this ArticleDto dto) => new() {
        Id = dto.Id,
        CatalogId = dto.Catalog.Id,
        Title = dto.Title,
        Description = dto.Description,
        DateOrBanner = dto.DateOrBanner,
    };
    public static List<ArticleDto> ToDtoList(this List<Article> entities) {
        var list = new List<ArticleDto>();
        foreach (var entity in entities) {
            list.Add(entity.ToDto());
        }
        return list;
    }
}