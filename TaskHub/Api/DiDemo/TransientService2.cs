namespace Api.DiDemo;

/// <summary>
/// Второй transient сервис
/// </summary>
public sealed class TransientService2 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}