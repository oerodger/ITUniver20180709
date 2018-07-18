using DocflowApp.Models.Listeners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DocflowApp.Models
{    
    public class BinaryFile
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        [CreationDate]
        public virtual DateTime? CreationDate { get; set; }

        [CreationAuthor]
        public virtual User CreationAuthor { get; set; }

        public virtual HttpPostedFileBase PostedFile { get; set; }
    }
}
