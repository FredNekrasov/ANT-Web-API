using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.WebAPI.dto;

namespace AlexanderNevskyTemple.WebAPI.mappers; 
public static class CatalogMapper {
    public static CatalogDto ToDto(this Catalog entity) => new() {
        Id = entity.Id,
        Name = entity.Name
    };
    public static Catalog ToEntity(this CatalogDto dto) => new() {
        Id = dto.Id,
        Name = dto.Name
    };
}