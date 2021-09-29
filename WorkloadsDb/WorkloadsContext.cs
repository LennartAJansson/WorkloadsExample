namespace WorkloadsDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    public class WorkloadsContext : DbContext, IUnitOfWork
    {
        private readonly ILoggerFactory loggerFactory;
        private ILogger<WorkloadsContext> logger;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public DbSet<Person> People { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Workload> Workloads { get; set; }

        public WorkloadsContext(DbContextOptions<WorkloadsContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            this.loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            logger = loggerFactory.CreateLogger<WorkloadsContext>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property("Firstname").HasMaxLength(200);
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(this);

            repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void AddXmlRepository<TEntity>(string path) where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) != true)
            {
                IGenericRepository<TEntity> repo = new XmlGenericRepository<TEntity>(path);
                repositories.Add(typeof(TEntity), repo);
            }
        }

        public Task EnsureDbExists(bool seed = false)
        {
            IEnumerable<string> migrations = Database.GetPendingMigrations();

            if (migrations.Any())
            {
                logger.LogInformation("Adding migrations");
                Database.Migrate();
            }

            return Task.CompletedTask;
        }
    }

}
