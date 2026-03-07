namespace Api.DiDemo;

/// <summary>
/// Второй scoped сервис
/// </summary>
public sealed class ScopedService2 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}