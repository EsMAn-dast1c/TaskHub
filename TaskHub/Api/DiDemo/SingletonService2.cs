namespace Api.DiDemo;

/// <summary>
/// Второй singleton сервис
/// </summary>
public sealed class SingletonService2 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}