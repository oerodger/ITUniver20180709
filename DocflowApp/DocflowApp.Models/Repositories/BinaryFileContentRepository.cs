using DocflowApp.Models.Filters;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models.Repositories
{
    [Repository]
    public class BinaryFileContentRepository : Repository<BinaryFileContent, BinaryFileContentFilter>
    {
        public BinaryFileContentRepository(ISession session) : base(session)
        {
        }

        public BinaryFileContent GetByBinaryFile(BinaryFile file)
        {
            var crit = session.CreateCriteria<BinaryFileContent>()
                .Add(Restrictions.Eq("BinaryFile.Id", file.Id))
                .SetMaxResults(1);
            return crit.List<BinaryFileContent>().FirstOrDefault();
        }

    }
}
