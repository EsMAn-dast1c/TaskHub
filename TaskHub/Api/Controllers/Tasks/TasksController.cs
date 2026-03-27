using Api.Attributes;
using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Logic.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

/// <summary>
/// Контроллер работы с задачами
/// </summary>
[ApiController]
[Route("tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    /// <summary>
    /// Создать задачу
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
        [FromBody] CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var task = await _taskService.CreateTaskAsync(
            request.Title!,
            request.CreatedByUserId,
            cancellationToken);

        var response = new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            CreatedByUserId = task.CreatedByUserId,
            CreatedUtc = task.CreatedUtc
        };

        return Created($"/tasks/{response.Id}", response);
    }

    /// <summary>
    /// Получить все задачи
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<TaskResponse>>> GetTasksAsync(
        CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetTasksAsync(cancellationToken);

        var response = tasks
            .Select(task => new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                CreatedByUserId = task.CreatedByUserId,
                CreatedUtc = task.CreatedUtc
            })
            .ToList();

        return Ok(response);
    }

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
        [FromRouteTaskId] Guid id,
        CancellationToken cancellationToken)
    {
        var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);

        if (task is null)
        {
            return NotFound();
        }

        var response = new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            CreatedByUserId = task.CreatedByUserId,
            CreatedUtc = task.CreatedUtc
        };

        return Ok(response);
    }

    /// <summary>
    /// Изменить название задачи
    /// </summary>
    [HttpPut("{id}/title")]
    public async Task<IActionResult> SetTaskTitleAsync(
        [FromRouteTaskId] Guid id,
        [FromBody] SetTaskTitleRequest request,
        CancellationToken cancellationToken)
    {
        await _taskService.SetTaskTitleAsync(id, request.Title!, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskByIdAsync(
        [FromRouteTaskId] Guid id,
        CancellationToken cancellationToken)
    {
        var deleted = await _taskService.DeleteTaskByIdAsync(id, cancellationToken);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> DeleteTasksAsync(CancellationToken cancellationToken)
    {
        await _taskService.DeleteTasksAsync(cancellationToken);
        return NoContent();
    }
}