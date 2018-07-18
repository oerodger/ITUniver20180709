using DocflowApp.Models.Autofac;
using DocflowApp.Models.Repositories;
using NHibernate.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocflowApp.Models.Listeners
{
    [Listener]
    public class CreationAuthorListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            return SetCreationProps(@event);
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            return new Task<bool>(() => {
                return SetCreationProps(@event);
            });
        }

        private bool SetCreationProps(PreInsertEvent @event)
        {
            if (@event.Entity != null)
            {
                var props = @event.Entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var attr = prop.GetCustomAttribute<CreationAuthorAttribute>();
                    if (attr == null)
                    {
                        continue;
                    }
                    var index = Array.IndexOf(@event.Persister.PropertyNames, prop.Name);
                    if (index >= 0)
                    {
                        var val = Locator.GetService<UserRepository>().GetCurrentUser();
                        prop.SetValue(@event.Entity, val);
                        @event.State[index] = val;
                    }                    
                }
            }
            return false;
        }
    }
}
