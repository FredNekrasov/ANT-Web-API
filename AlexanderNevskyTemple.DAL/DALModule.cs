using AlexanderNevskyTemple.DAL.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlexanderNevskyTemple.DAL;

public static class DALModule {
    public static IServiceCollection AddDALModule(this IServiceCollection services, string? connectionString) {
        services.AddDbContext<ANTDbContext>(options => options.UseSqlServer(connectionString));
        services.AddSingleton<CatalogRepository>();
        services.AddSingleton<ArticleRepository>();
        services.AddSingleton<ContentRepository>();
        return services;
    }
}