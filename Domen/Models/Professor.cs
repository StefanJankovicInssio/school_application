using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    public class Professor : BaseEntity
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; } = new HashSet<ProfessorCourse>();

    }
}
