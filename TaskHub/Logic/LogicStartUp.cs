using Logic.Users.Services;
using Logic.Users.Services.Interfaces;
using Logic.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

/// <summary>
/// Регистрация зависимостей слоя логики
/// </summary>
public static class LogicStartUp
{
    /// <summary>
    /// Добавить зависимости логики: сервисы
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddLogic(this IServiceCollection services)
    {
        // Users
        services.AddScoped<IUserService, UserService>();

        // Tasks
        services.AddScoped<ITaskService, TaskService>();
    }
}