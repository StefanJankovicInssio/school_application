using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDepertmentService
    {
        public IEnumerable<Department> All();

    }
}
