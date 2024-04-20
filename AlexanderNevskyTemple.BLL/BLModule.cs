using AlexanderNevskyTemple.BLL.interactors;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.BLL;

public static class BLModule {
    public static IServiceCollection AddBLModule(this IServiceCollection services) {
        services.AddScoped<CatalogInteractor>();
        services.AddScoped<ArticleInteractor>();
        services.AddScoped<ContentInteractor>();
        return services;
    }
}