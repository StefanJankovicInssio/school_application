using Domen.Models;
using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; } = new HashSet<ProfessorCourse>();

    }
}
