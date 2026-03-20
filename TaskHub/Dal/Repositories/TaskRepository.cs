using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _taskDbContext;

    public TaskRepository(TaskDbContext taskDbContext)
    {
        _taskDbContext = taskDbContext;
    }

    public async Task<TaskEntity> CreateTaskAsync(
        string title,
        Guid createdByUserId,
        DateTimeOffset createdUtc,
        CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedByUserId = createdByUserId,
            CreatedUtc = createdUtc
        };

        await _taskDbContext.Tasks.AddAsync(task, cancellationToken);
        await _taskDbContext.SaveChangesAsync(cancellationToken);

        return task;
    }

    public async Task<IReadOnlyCollection<TaskEntity>> GetTasksAsync(CancellationToken cancellationToken)
    {
        return await _taskDbContext.Tasks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _taskDbContext.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        var task = await _taskDbContext.Tasks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (task is null)
        {
            return;
        }

        task.Title = title;

        await _taskDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _taskDbContext.Tasks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (task is null)
        {
            return false;
        }

        _taskDbContext.Tasks.Remove(task);
        await _taskDbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task DeleteTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskDbContext.Tasks.ToListAsync(cancellationToken);

        _taskDbContext.Tasks.RemoveRange(tasks);
        await _taskDbContext.SaveChangesAsync(cancellationToken);
    }
}