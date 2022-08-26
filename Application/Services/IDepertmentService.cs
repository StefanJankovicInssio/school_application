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
    public interface IDepertmentService
    {
        public Task<ServiceResponse<IEnumerable<GetDepartmentDto>>> GetDepartments();
        public Task<ServiceResponse<GetDepartmentDto>> GetDepartment(int departmentId);
        public Task AddDepartment (AddDepartmentDto department);
        public Task EditDepartment(int departmentId, EditDepartmentDto department);
        public Task DeleteDepartment(int departmentId);
    }
}
