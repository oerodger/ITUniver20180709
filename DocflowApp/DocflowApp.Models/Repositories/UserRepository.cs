﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DocflowApp.Models.Filters;
using Microsoft.AspNet.Identity;
using NHibernate;
using NHibernate.Criterion;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class UserRepository : Repository<User, UserFilter>
    {
        public UserRepository(ISession session) : 
            base(session)
        {
        }

        public override void SetupFilter(UserFilter filter, ICriteria crit)
        {
            base.SetupFilter(filter, crit);
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
                if (filter.Date != null)
                {
                    if (filter.Date.From.HasValue)
                    {
                        crit.Add(Restrictions.Ge("WorkStartDate", filter.Date.From.Value));
                    }
                    if (filter.Date.To.HasValue)
                    {
                        crit.Add(Restrictions.Le("WorkStartDate", filter.Date.To.Value));
                    }
                }
            }
        }

        public IList<User> Find(UserFilter filter, FetchOptions options = null)
        {
            var crit = session.CreateCriteria<User>();
            SetupFilter(filter, crit);
            SetupFetchOptions(crit, options);
            return crit.List<User>();
        }

        public long Count(UserFilter filter)
        {
            var crit = session.CreateCriteria<User>();
            SetupFilter(filter, crit);
            crit.SetProjection(Projections.Count("Id"));
            return Convert.ToInt64(crit.UniqueResult());
        }

        public User GetCurrentUser(IPrincipal user = null)
        {
            user = user ?? HttpContext.Current.User;
            if (user == null || user.Identity == null)
            {
                return null;
            }
            var currentUserId = user.Identity.GetUserId();
            long userId;
            if (string.IsNullOrEmpty(currentUserId) || !long.TryParse(currentUserId, out userId))
            {
                return null;
            }
            return Load(userId);
        }
    }
}
