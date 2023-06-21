using Pustok.Business.Services.Implementations;
using Pustok.Business.Services.Interfaces;

namespace Pustok.API.Extensions;

public static class AddServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
