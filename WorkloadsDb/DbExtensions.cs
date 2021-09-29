namespace WorkloadsDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using WorkloadsDb.Abstract;

    public static class DbExtensions
    {
        public static IServiceCollection AddWorkloadsDb(this IServiceCollection services, string connectionString, string xmlPath)
        {
            services.AddTransient<IWorkloadsService, WorkloadsService>();
            services.AddDbContext<IUnitOfWork, WorkloadsContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
