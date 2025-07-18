using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPractice.Application.Contract.Interfaces;
using MyPractice.CleanArchitecture.Domain.Entities;
using MyPractice.Persistant.Repositories;

namespace MyPractice.Persistant;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITodoListRepository, TodoListRepository>();
        services.AddScoped<ITodoListRepositoryQuery, TodoListRepositoryQuery>();
        return services;
    }
}