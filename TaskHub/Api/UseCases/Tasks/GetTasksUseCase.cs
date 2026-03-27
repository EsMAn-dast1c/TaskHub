using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks;

public sealed class GetTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IReadOnlyCollection<TaskEntity>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _taskRepository.GetTasksAsync(cancellationToken);
    }
}