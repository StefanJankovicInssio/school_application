using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
