using Dal.Context;
using Dal.Repositories;
using Dal.Repositories.Interfaces;
using DatabaseLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

/// <summary>
/// Регистрация зависимостей слоя доступа к данным
/// </summary>
public static class DalStartUp
{
    /// <summary>
    /// Добавить зависимости DAL: DbContext и репозитории
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddDal(this IServiceCollection services)
    {
        // DbContext
        services.AddDatabase<UserDbContext>();
        services.AddDatabase<TaskDbContext>();

        // Users
        services.AddScoped<IUserRepository, UserRepository>();

        // Tasks
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}
