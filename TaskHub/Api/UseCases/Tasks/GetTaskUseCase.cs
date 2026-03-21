using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks;

public sealed class GetTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskEntity?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetTaskByIdAsync(id, cancellationToken);
    }
}