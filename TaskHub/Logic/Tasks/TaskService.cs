using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;
using Dal.Repositories.Interfaces;

namespace Logic.Tasks;

public sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskEntity> CreateTaskAsync(
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

    public async Task<IReadOnlyCollection<TaskEntity>> GetTasksAsync(CancellationToken cancellationToken)
    {
        return await _taskRepository.GetTasksAsync(cancellationToken);
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetTaskByIdAsync(id, cancellationToken);
    }

    public async Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        await _taskRepository.SetTaskTitleAsync(id, title, cancellationToken);
    }

    public async Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _taskRepository.DeleteTaskByIdAsync(id, cancellationToken);
    }

    public async Task DeleteTasksAsync(CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteTasksAsync(cancellationToken);
    }
}