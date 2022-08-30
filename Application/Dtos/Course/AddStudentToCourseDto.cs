using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Course
{
    public class AddStudentToCourseDto
    {
        public int studentId { get; set; }
        public int courseId { get; set; }
    }
}
