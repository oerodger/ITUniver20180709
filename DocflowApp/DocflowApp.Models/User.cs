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
        public virtual string UserName { get; set; }
        
        public virtual string Password { get; set; }

        [Display(Name = "ФИО")]
        public virtual string FIO { get; set; }

        [Display(Name = "Дата начала работы")]
        public virtual DateTime? WorkStartDate { get; set; }
    }
}
