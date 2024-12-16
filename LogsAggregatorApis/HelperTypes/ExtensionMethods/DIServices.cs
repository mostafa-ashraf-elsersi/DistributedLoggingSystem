using LogsAggregatorApis.BusinessLayer.LogItemService;
using LogsAggregatorApis.DataAccessLayer;
using LogsAggregatorApis.DataAccessLayer.GenericDbRepositoryAbstraction;
using LogsAggregatorApis.HelperTypes.General;

namespace LogsAggregatorApis.HelperTypes.ExtensionMethods
{
    public static class DIServices
    {
        private const string CORS_POLICY = nameof(CORS_POLICY);

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            // Add services to the DI container:

            builder.Services.AddControllers();

            builder.Services.Configure<AppDbSettings>(builder.Configuration.GetSection(nameof(AppDbSettings)));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY, policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped(typeof(IGenericDbRepository<>), typeof(MongoDbRepository<>));

            builder.Services.AddScoped<ILogItemService, LogItemService>();
        }

        public static void ConsumeServices(this WebApplication webApplication)
        {
            webApplication.UseHttpsRedirection();

            webApplication.UseCors(CORS_POLICY);

            webApplication.UseAuthorization();

            webApplication.MapControllers();
        }
    }
}
