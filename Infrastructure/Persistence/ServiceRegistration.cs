using Application.Repositories.CompanyRepo;
using Application.Repositories.OrderRepo;
using Application.Repositories.ProductRepo;
using Application.Services;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Company;
using Persistence.Repositories.Order;
using Persistence.Repositories.Product;
using Persistence.Services;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<NetChallengeDbContext>(options => options.UseSqlServer(Configuration.ConnectionString!));

        services.AddScoped<ICompanyReadRepo, CompanyReadRepo>();
        services.AddScoped<ICompanyWriteRepo, CompanyWriteRepo>();
        services.AddScoped<IProductReadRepo, ProductReadRepo>();
        services.AddScoped<IProductWriteRepo, ProductWriteRepo>();
        services.AddScoped<IOrderReadRepo, OrderReadRepo>();
        services.AddScoped<IOrderWriteRepo, OrderWriteRepo>();


        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
    }
}