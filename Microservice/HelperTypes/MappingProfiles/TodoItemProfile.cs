using AutoMapper;
using Microservice.DatabaseLayer;
using Microservice.HelperTypes.Dtos.TodoItemDtos;

namespace Microservice.HelperTypes.MappingProfiles
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();
        }
    }
}
