namespace Api.DiDemo;

/// <summary>
/// Первый transient сервис
/// </summary>
public sealed class TransientService1 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}