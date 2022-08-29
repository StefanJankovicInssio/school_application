using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Course
{
    public class AddCourseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int DepartmentId { get; set; }
    }
}
