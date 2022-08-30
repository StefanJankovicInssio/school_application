using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Professor
{
    public class EditProfessorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDto Address { get; set; }

    }
}
