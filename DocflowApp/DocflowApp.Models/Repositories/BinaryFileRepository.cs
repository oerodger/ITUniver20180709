using DocflowApp.Models.Filters;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class BinaryFileRepository : Repository<BinaryFile, BinaryFileFilter>
    {
        public BinaryFileRepository(ISession session) : base(session)
        {
        }
    }
}
