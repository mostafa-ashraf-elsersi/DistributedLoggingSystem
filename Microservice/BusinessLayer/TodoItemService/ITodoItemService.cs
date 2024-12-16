using Microservice.HelperTypes.Dtos.TodoItemDtos;

namespace Microservice.BusinessLayer.TodoItemService
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItemDto> GetAll();

        TodoItemDto Get(int id);
    }
}
