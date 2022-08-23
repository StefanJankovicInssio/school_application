using Domen.Models;
using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
