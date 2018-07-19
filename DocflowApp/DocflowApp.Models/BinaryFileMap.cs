using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class BinaryFileMap: ClassMap<BinaryFile>
    {
        public BinaryFileMap()
        {
            Id(f => f.Id).GeneratedBy.Identity();
            Map(f => f.Name);
            Map(f => f.CreationDate);
            References(f => f.CreationAuthor);
            Map(f => f.ContentType);
            
        }
    }
}
