namespace Microservice.HelperTypes.Dtos.TodoItemDtos
{
    public record TodoItemDto(int Id,
                              string? Title,
                              DateOnly? DueBy = null,
                              bool IsComplete = false);
}
