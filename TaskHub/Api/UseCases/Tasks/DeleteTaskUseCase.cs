using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks;

public sealed class DeleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _taskRepository.DeleteTaskByIdAsync(id, cancellationToken);
    }
}