using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class BinaryFileContentMap: ClassMap<BinaryFileContent>
    {
        public BinaryFileContentMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            References(c => c.BinaryFile).Cascade.SaveUpdate();
            Map(c => c.Content).Length(int.MaxValue);
        }
    }
}
