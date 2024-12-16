using AutoMapper;
using Microservice.DatabaseLayer.AppDbContext;
using Microservice.HelperTypes.Dtos.TodoItemDtos;
using Microsoft.EntityFrameworkCore;

namespace Microservice.BusinessLayer.TodoItemService
{
    public class TodoItemService : ITodoItemService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TodoItemService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<TodoItemDto> GetAll()
        {
            var todoItems = _dbContext
                .TodoItems
                .AsNoTracking();

            var todoItemsDtos = _mapper.Map<List<TodoItemDto>>(todoItems);

            return todoItemsDtos;
        }

        public TodoItemDto Get(int id)
        {
            var todoItem = _dbContext
                .TodoItems
                .AsNoTracking()
                .FirstOrDefault(item => item.Id == id);

            var todoItemDto = _mapper.Map<TodoItemDto>(todoItem);

            return todoItemDto;
        }
    }
}
