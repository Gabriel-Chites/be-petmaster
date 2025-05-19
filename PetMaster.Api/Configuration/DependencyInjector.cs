using Microsoft.EntityFrameworkCore;
using PetMaster.Domain.Repositories;
using PetMaster.Domain.Services;
using PetMaster.Domain.Services.Interfaces;
using PetMaster.Infra.Context;
using PetMaster.Infra.Repositories;

namespace PetMaster.Api.Configuration;

public static class DependencyInjector
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration) 
    {
        #region Domain
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPetService, PetService>();
        services.AddScoped<IResponsibleService, ResponsibleService>();
        #endregion

        #region Infra
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
        #endregion

        #region Database
        services.AddDbContext<PetMasterContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        #endregion
    }
}
