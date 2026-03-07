using System;

namespace Api.DiDemo;

/// <summary>
/// Интерфейс для получения идентификатора экземпляра
/// </summary>
public interface IHasInstanceId
{
    Guid InstanceId { get; }
}