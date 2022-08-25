using Application.Models;
using Domain.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Abstractions.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {

    }
}
