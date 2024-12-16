
using LogsAggregatorApis.HelperTypes.ExtensionMethods;

namespace LogsAggregatorApis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.RegisterServices();

            var app = builder.Build();

            app.ConsumeServices();

            app.Run();
        }
    }
}
