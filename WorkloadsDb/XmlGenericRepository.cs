namespace WorkloadsDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;

    public class XmlGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public XmlGenericRepository(string path)
        {
            //Create XmlParser and Parse the Xml to ICollection<TEntity>
        }

        public void Delete(TEntity entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            //Implement
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            //Implement
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}