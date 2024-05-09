using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.DAL.entities;
using AutoMapper;

namespace AlexanderNevskyTemple.DAL.mappers;
public class EntityMapper : Profile {
    public EntityMapper()
    {
        CreateMap<CatalogModel, Catalog>();
        CreateMap<Catalog, CatalogModel>();

        CreateMap<ContentModel, Content>();
        CreateMap<Content, ContentModel>();
    }
}