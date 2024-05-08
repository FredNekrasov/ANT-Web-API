using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.DAL.repositories;
using AlexanderNevskyTemple.DAL.repositories.impl;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.DAL;

public static class DALModule {
    public static IServiceCollection AddDALModule(this IServiceCollection services) {
        services.AddDbContext<ANTDbContext>();
        services.AddScoped<IRepository<Catalog, int>, CatalogRepository>();
        services.AddScoped<IRepository<Article, long>, ArticleRepository>();
        services.AddScoped<IRepository<Content, long>, ContentRepository>();
        return services;
    }
}