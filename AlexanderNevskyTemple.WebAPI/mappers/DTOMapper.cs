using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;

namespace AlexanderNevskyTemple.WebAPI.mappers;
public class DTOMapper : Profile {
    public DTOMapper() {
        CreateMap<CatalogModel, CatalogDto>();
        CreateMap<CatalogDto, CatalogModel>();

        CreateMap<ArticleModel, ArticleDto>();
        CreateMap<ArticleDto, ArticleModel>();

        CreateMap<ContentModel, ContentDto>();
        CreateMap<ContentDto, ContentModel>();
    }
}