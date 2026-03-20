using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks;

public sealed class CreateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskEntity> ExecuteAsync(
        string title,
        Guid createdByUserId,
        CancellationToken cancellationToken)
    {
        return await _taskRepository.CreateTaskAsync(
            title,
            createdByUserId,
            DateTimeOffset.UtcNow,
            cancellationToken);
    }
}