using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Persistence.Contexts;
using ETradeBackend.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETradeBackend.Persistence.Extensions.Ioc;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ETradeBackendContext>(options => options.UseSqlServer(configuration.GetConnectionString("etrade")));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IAdvertPhotoPathRepository, AdvertPhotoPathRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICorporateAdvertRepository, CorporateAdvertRepository>();
        services.AddScoped<ICorporateAdvertOrderRepository, CorporateAdvertOrderRepository>();
        services.AddScoped<ICorporateAdvertOrderItemRepository, CorporateAdvertOrderItemRepository>();
        services.AddScoped<ICorporateUserRepository, CorporateUserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IIndividualAdvertRepository, IndividualAdvertRepository>();
        services.AddScoped<IIndividualUserRepository, IndividualUserRepository>();
        services.AddScoped<INeighbourhoodRepository, NeighbourhoodRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISwapAdvertRepository, SwapAdvertRepository>();
        services.AddScoped<ISwapForCategoryAdvertRepository, SwapForCategoryAdvertRepository>();
        services.AddScoped<ISwapForProductAdvertRepository, SwapForProductAdvertRepository>();
        services.AddScoped<IUserAddressRepository, UserAddressRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
