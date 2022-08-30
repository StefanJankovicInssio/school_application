using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Student
{
    public class EditStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Index { get; set; }
        public AddressDto Address { get; set; }

    }
}
