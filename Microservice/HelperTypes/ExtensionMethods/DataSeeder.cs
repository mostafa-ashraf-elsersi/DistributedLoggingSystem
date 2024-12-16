using Microservice.DatabaseLayer.AppDbContext;
using Microservice.DatabaseLayer;

namespace Microservice.HelperTypes.ExtensionMethods
{
    public static class DataSeeder
    {
        public static void SeedData(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                dbContext.AddRangeAsync([
                    new TodoItem { Id = 1, Title = "Buy groceries", DueBy = new DateOnly(2024, 12, 15), IsCompleted = false },
                    new TodoItem { Id = 2, Title = "Finish project report", DueBy = new DateOnly(2024, 12, 18), IsCompleted = false },
                    new TodoItem { Id = 3, Title = "Call plumber", DueBy = new DateOnly(2024, 12, 16), IsCompleted = true },
                    new TodoItem { Id = 4, Title = "Plan weekend trip", DueBy = null, IsCompleted = false },
                    new TodoItem { Id = 5, Title = "Schedule dentist appointment", DueBy = new DateOnly(2024, 12, 20), IsCompleted = false },
                    new TodoItem { Id = 6, Title = "Update LinkedIn profile", DueBy = new DateOnly(2024, 12, 19), IsCompleted = false }
                ]);

                dbContext.SaveChanges();
            }
        }
    }
}
