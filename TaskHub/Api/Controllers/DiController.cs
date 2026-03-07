using Api.DiDemo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Контроллер для демонстрации жизненных циклов DI
/// </summary>
[ApiController]
[Route("[controller]")]
public sealed class DiController : ControllerBase
{
    private readonly SingletonService1 _singleton1;
    private readonly SingletonService2 _singleton2;
    private readonly ScopedService1 _scoped1;
    private readonly ScopedService2 _scoped2;
    private readonly TransientService1 _transient1;
    private readonly TransientService2 _transient2;

    public DiController(
        SingletonService1 singleton1,
        SingletonService2 singleton2,
        ScopedService1 scoped1,
        ScopedService2 scoped2,
        TransientService1 transient1,
        TransientService2 transient2)
    {
        _singleton1 = singleton1;
        _singleton2 = singleton2;
        _scoped1 = scoped1;
        _scoped2 = scoped2;
        _transient1 = transient1;
        _transient2 = transient2;
    }

    /// <summary>
    /// Возвращает идентификаторы экземпляров сервисов
    /// </summary>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Singleton1 = _singleton1.InstanceId,
            Singleton2 = _singleton2.InstanceId,
            Scoped1 = _scoped1.InstanceId,
            Scoped2 = _scoped2.InstanceId,
            Transient1 = _transient1.InstanceId,
            Transient2 = _transient2.InstanceId
        });
    }
}