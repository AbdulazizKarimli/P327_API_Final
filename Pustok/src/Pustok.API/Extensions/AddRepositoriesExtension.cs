using Pustok.DataAccess.Repositories.Implementations;
using Pustok.DataAccess.Repositories.Interfaces;

namespace Pustok.API.Extensions;

public static class AddRepositoriesExtension
{
    public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
