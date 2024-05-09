using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.BLL.interactors.impl;
using AlexanderNevskyTemple.BLL.models;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.BLL;

public static class BLModule {
    public static IServiceCollection AddBLModule(this IServiceCollection services) {
        services.AddScoped<IInteractor<CatalogModel, int>, CatalogInteractor>();
        services.AddScoped<IInteractor<ArticleModel, long>, ArticleInteractor>();
        services.AddScoped<IInteractor<ContentModel, long>, ContentInteractor>();
        return services;
    }
}