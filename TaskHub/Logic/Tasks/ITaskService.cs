using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entities;

namespace Logic.Tasks;

public interface ITaskService
{
    Task<TaskEntity> CreateTaskAsync(
        string title,
        Guid createdByUserId,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TaskEntity>> GetTasksAsync(CancellationToken cancellationToken);

    Task<TaskEntity?> GetTaskByIdAsync(Guid id, CancellationToken cancellationToken);

    Task SetTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);

    Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeleteTasksAsync(CancellationToken cancellationToken);
}
