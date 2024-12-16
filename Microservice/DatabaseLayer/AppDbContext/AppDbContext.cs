using Microservice.DatabaseLayer;
using Microsoft.EntityFrameworkCore;

namespace Microservice.DatabaseLayer.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
