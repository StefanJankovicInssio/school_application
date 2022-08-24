using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    public class Professor : Person
    {
        public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; } = new HashSet<ProfessorCourse>();

    }
}
