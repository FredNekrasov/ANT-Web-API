using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.WebAPI.dto;

namespace AlexanderNevskyTemple.WebAPI.mappers;
public static class ArticleMapper {
    public static ArticleDto ToDto(this Article entity) => new() {
        Id = entity.Id,
        Catalog = entity.Catalog.ToDto(),
        Title = entity.Title,
        Description = entity.Description,
        Date = entity.Date
    };
    public static Article ToEntity(this ArticleDto dto) => new() {
        Id = dto.Id,
        CatalogId = dto.Catalog.Id,
        Title = dto.Title,
        Description = dto.Description,
        Date = dto.Date,
    };
}