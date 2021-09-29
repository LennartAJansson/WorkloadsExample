namespace AssignmentGenerator
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using WorkloadsDb;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Generate();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<Generator>();
                    services.AddDbContext<WorkloadsContext>(options =>
                    {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("WorkloadsDb"));
                    });
                });
        }
    }
}
