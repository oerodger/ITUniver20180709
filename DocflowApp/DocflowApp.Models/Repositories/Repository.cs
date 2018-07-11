using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DocflowApp.Models.Repositories
{
    public class Repository<T>
        where T: class
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual T Load(long id)
        {
            return session.Load<T>(id);
        }

        public virtual void Save(T entity)
        {
            session.Save(entity);
        }

        public virtual IList<T> FindAll()
        {
            var crit = session.CreateCriteria<T>();
            return crit.List<T>();
        }

        public virtual void SetupFetchOptions(ICriteria crit, FetchOptions options)
        {
            if (options != null)
            {
                if (options.Start > 0)
                {
                    crit.SetFirstResult(options.Start);
                }
                if (options.Count > 0)
                {
                    crit.SetMaxResults(options.Count);
                }
                if (!string.IsNullOrEmpty(options.SortExpression))
                {
                    crit.AddOrder(options.SortDirection == SortDirection.Ascending ? 
                        Order.Asc(options.SortExpression) : 
                        Order.Desc(options.SortExpression));
                }
            }
        }
    }
}
