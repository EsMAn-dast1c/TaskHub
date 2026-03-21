namespace Api.Controllers.Tasks.Request;

public sealed class CreateTaskRequest
{
    public string? Title { get; set; }

    public Guid CreatedByUserId { get; set; }
}