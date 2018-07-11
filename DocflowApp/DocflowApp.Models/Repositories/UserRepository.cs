using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocflowApp.Models.Filters;
using NHibernate;
using NHibernate.Criterion;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class UserRepository : Repository<User>
    {
        public UserRepository(ISession session) : 
            base(session)
        {
        }

        public IList<User> Find(UserFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<User>();
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.UserName))
                {
                    crit.Add(Restrictions.Eq("UserName", filter.UserName));
                }
                if (!string.IsNullOrEmpty(filter.FIO))
                {
                    crit.Add(Restrictions.Like("FIO", filter.FIO, MatchMode.Anywhere));
                }
            }
            SetupFetchOptions(crit, options);
            return crit.List<User>();
        }
    }
}
