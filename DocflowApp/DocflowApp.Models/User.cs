using DocflowApp.Models.Listeners;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocflowApp.Models
{
    public class User: IUser<long>
    {
        public virtual long Id { get; set; }

        [Display(Name = "Логин")]
        [InFastSearch]
        public virtual string UserName { get; set; }
        
        public virtual string Password { get; set; }

        [Display(Name = "ФИО")]
        [InFastSearch]
        public virtual string FIO { get; set; }

        [Display(Name = "Дата начала работы")]
        [CreationDate]
        public virtual DateTime? WorkStartDate { get; set; }

        [CreationAuthor]
        public virtual User CreationAuthor { get; set; }
    }
}
