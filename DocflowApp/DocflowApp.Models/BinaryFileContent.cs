using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class BinaryFileContent
    {
        public virtual long Id { get; set; }

        public virtual BinaryFile BinaryFile { get; set; }

        public virtual byte[] Content { get; set; }
    }
}
