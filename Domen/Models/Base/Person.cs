using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.Base
{
    public abstract class Person: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

    }
}
