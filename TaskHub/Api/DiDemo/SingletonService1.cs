namespace Api.DiDemo;

/// <summary>
/// Первый singleton сервис
/// </summary>
public sealed class SingletonService1 : DisposedService, IHasInstanceId
{
    public Guid InstanceId => base.InstanceId;
}