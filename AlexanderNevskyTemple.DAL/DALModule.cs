using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;
using AlexanderNevskyTemple.DAL.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.DAL;

public static class DALModule {
    public static IServiceCollection AddDALModule(this IServiceCollection services) {
        services.AddDbContext<ANTDbContext>();
        services.AddScoped<IRepository<CatalogModel, int>, CatalogRepository>();
        services.AddScoped<IRepository<ArticleModel, long>, ArticleRepository>();
        services.AddScoped<IRepository<ContentModel, long>, ContentRepository>();
        return services;
    }
}