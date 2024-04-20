using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;

namespace AlexanderNevskyTemple.WebAPI.mappers; 
public class SimpleMapper : Profile {
    public SimpleMapper() {
        CreateMap<Catalog, CatalogDto>();
        CreateMap<CatalogDto, Catalog>();

        CreateMap<Content, ContentDto>();
        CreateMap<ContentDto, Content>();
    }
}