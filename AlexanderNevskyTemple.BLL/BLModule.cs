using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.BLL.interactors.impl;
using AlexanderNevskyTemple.DAL.entities;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.BLL;

public static class BLModule {
    public static IServiceCollection AddBLModule(this IServiceCollection services) {
        services.AddScoped<IInteractor<Catalog, int>, CatalogInteractor>();
        services.AddScoped<IInteractor<Article, long>, ArticleInteractor>();
        services.AddScoped<IInteractor<Content, long>, ContentInteractor>();
        return services;
    }
}