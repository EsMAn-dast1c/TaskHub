namespace Api.DiDemo;

/// <summary>
/// Первый scoped сервис
/// </summary>
public sealed class ScopedService1 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}