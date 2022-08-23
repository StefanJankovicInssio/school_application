using Domen.Models;
using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Student : Person
    {
        public Address Address { get; set; }
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
