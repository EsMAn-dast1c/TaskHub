using System;

namespace Api.DiDemo;

/// <summary>
/// Базовый сервис который показывает создание и удаление объектов
/// </summary>
public abstract class DisposedService : IDisposable
{
    /// <summary>
    /// Уникальный идентификатор экземпляра
    /// </summary>
    protected Guid InstanceId { get; } = Guid.NewGuid();

    protected DisposedService()
    {
        Console.WriteLine($"{GetType().Name} created: {InstanceId}");
    }

    public void Dispose()
    {
        Console.WriteLine($"{GetType().Name} disposed: {InstanceId}");
    }
}