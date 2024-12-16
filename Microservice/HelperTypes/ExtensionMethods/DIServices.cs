using Microservice.BusinessLayer.TodoItemService;
using Microservice.DatabaseLayer.AppDbContext;
using Microservice.PresentationLayer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Debugging;

namespace Microservice.HelperTypes.ExtensionMethods
{
    public static class DIServices
    {
        private const string CORS_POLICY = nameof(CORS_POLICY);

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(nameof(AppDbContext));
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            SelfLog.Enable(Console.Out);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY, policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<ITodoItemService, TodoItemService>();
        }

        public static void ConsumeServices(this WebApplication webApplication)
        {
            webApplication.UseHttpsRedirection();

            webApplication.UseSerilogRequestLogging();

            webApplication.UseCors(CORS_POLICY);

            webApplication.SeedData();

            webApplication.RegisterTodoItemApiGroup();
        }
    }
}
