using Application.Dtos.Department;
using Application.Models;
using Infrastructure.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<GetDepartmentDto>> Get();
        public Task<GetDepartmentDto> GetById(int id);
        public Task<GetDepartmentDto> GetByName(string name);
        public Task Add (AddDepartmentDto data);
        public Task EditById(int id, EditDepartmentDto data);
        public Task DeleteById(int id);
    }
}
