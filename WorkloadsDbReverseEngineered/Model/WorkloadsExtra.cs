namespace WorkloadsDb.Model
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class WorkloadsContext : IUnitOfWork
    {
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

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
                //logger.LogInformation("Adding migrations");
                Database.Migrate();
            }

            return Task.CompletedTask;
        }
    }
}
