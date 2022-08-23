using Domen.Models;
using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
