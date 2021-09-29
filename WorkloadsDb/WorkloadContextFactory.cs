namespace WorkloadsDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Logging;

    public class WorkloadContextFactory : IDesignTimeDbContextFactory<WorkloadsContext>
    {
        private static readonly string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WorkloadsDev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public WorkloadsContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<WorkloadsContext> optionsBuilder = new DbContextOptionsBuilder<WorkloadsContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            return new WorkloadsContext(optionsBuilder.Options, MyLoggerFactory);
        }
    }

}
