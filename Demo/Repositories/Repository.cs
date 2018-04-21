using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using Demo.Entities;

namespace Demo.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        private ISessionFactory sessionFactory = null;
        protected Repository()
        {
            if (sessionFactory == null)
                sessionFactory = UnitOfWork.GetSessionFactory();
        }

        public void CreateDataBase()
        {
            var Schema = new SchemaExport(UnitOfWork.GetConfiguration());
            Schema.Drop(true, true);
            Schema.Create(true, true);
        }
        public void Save(T entity)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                    session.Close();
                }
            }
        }

        public void Delete(T entity)
        {
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                    session.Close();
                }
            }
        }

        public T GetById(int id)
        {
            using (var session = sessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> GetAll()
        {
            using (var session = sessionFactory.OpenSession())
            {
                return session.Query<T>().ToList<T>();
            }
        }

    }
}
