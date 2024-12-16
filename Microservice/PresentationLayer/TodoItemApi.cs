using Microservice.BusinessLayer.TodoItemService;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.PresentationLayer
{
    public static class TodoItemApi
    {
        public static void RegisterTodoItemApiGroup(this WebApplication webApplication)
        {
            var apiGroup = webApplication.MapGroup("api/todo-items");

            apiGroup.MapGet("/", ([FromServices] ITodoItemService todoItemService) =>
            {
                var todoItemsDtos = todoItemService.GetAll();

                return todoItemsDtos.Any() ? Results.Ok(todoItemsDtos) : Results.NotFound();
            });

            apiGroup.MapGet("/{id}", (int id, [FromServices] ITodoItemService todoItemService) =>
            {
                var todoItemsDto = todoItemService.Get(id);

                return todoItemsDto is not null ? Results.Ok(todoItemsDto) : Results.NotFound();
            });
        }
    }
}
