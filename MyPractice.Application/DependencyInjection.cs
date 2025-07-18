using Microsoft.Extensions.DependencyInjection;
using MyPractice.Application.Contract.Interfaces.Services;
using MyPractice.Application.Services;

namespace MyPractice.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoListService, TodoListService>();
        return services;
    }
}