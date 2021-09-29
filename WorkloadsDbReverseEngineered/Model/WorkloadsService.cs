namespace WorkloadsDb.Model
{
    using Microsoft.Extensions.Logging;

    using System.Collections.Generic;

    public class WorkloadsService : IWorkloadsService
    {
        private readonly ILogger<WorkloadsService> logger;
        private readonly IUnitOfWork context;

        public WorkloadsService(ILogger<WorkloadsService> logger, IUnitOfWork context)
        {
            this.logger = logger;
            this.context = context;
            context.EnsureDbExists();
        }
        public IEnumerable<Assignment> GetAllAssignments()
        {
            return context.Repository<Assignment>().Get();
        }

        public IEnumerable<Assignment> GetAssignment(int id)
        {
            return context.Repository<Assignment>().Get(a => a.AssignmentId == id);
        }

        public void ParseXml<TEntity>(string path) where TEntity : class
        {
            context.AddXmlRepository<TEntity>(path);
        }

        public object GetXmlValue(int id)
        {
            //object should be your datatype from xml
            return context.Repository<object>().GetById(id);
        }
    }
}
