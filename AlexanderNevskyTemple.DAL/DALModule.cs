using AlexanderNevskyTemple.DAL.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.DAL;

public static class DALModule {
    public static IServiceCollection AddDALModule(this IServiceCollection services) {
        services.AddDbContext<ANTDbContext>();
        services.AddSingleton<CatalogRepository>();
        services.AddSingleton<ArticleRepository>();
        services.AddSingleton<ContentRepository>();
        return services;
    }
}