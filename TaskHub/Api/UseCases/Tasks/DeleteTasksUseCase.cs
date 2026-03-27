using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks;

public sealed class DeleteTasksUseCase
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTasksUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteTasksAsync(cancellationToken);
    }
}