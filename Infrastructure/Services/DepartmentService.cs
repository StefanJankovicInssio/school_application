using Application;
using Application.Data;
using Application.Dtos.Department;
using Application.Models;
using Application.Services;
using Domain.Infrastructure;
using Domain.Service;
using Infrastructure.Dtos.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepertmentService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        public DepartmentService()
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
        }

        public async Task AddDepartment(AddDepartmentDto department)
        {
            Department newDepartment = new Department();
            newDepartment.Name = department.Name;

            await unitOfWork.DepartmentRepository.Insert(newDepartment);
            await unitOfWork.Save();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await dbContext.Departments.FindAsync(departmentId);

            await unitOfWork.DepartmentRepository.Delete(department.Id);
        }

        public async Task EditDepartment(int departmentId, EditDepartmentDto department)
        {
            var currentDepartment = await dbContext.Departments.FindAsync(departmentId);

            currentDepartment.Name = department.Name;

            await unitOfWork.DepartmentRepository.Update(currentDepartment);
            unitOfWork.Save();
        }

        public async Task<ServiceResponse<GetDepartmentDto>> GetDepartment(int departmentId)
        {
            var department = await dbContext.Departments
                .Where(x => x.Id == departmentId)
                .Select(x => new GetDepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();

            if (department == null)
            {
                return new ServiceResponse<GetDepartmentDto> { Success = false, ErrorMessage = "There is no department for this id" };
            }

            return new ServiceResponse<GetDepartmentDto>
            {
                Data = department
            };
        }

        public async Task<ServiceResponse<IEnumerable<GetDepartmentDto>>> GetDepartments()
        {
            IEnumerable<GetDepartmentDto> departments = await dbContext.Departments.Select(x => new GetDepartmentDto
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();

            return new ServiceResponse<IEnumerable<GetDepartmentDto>> { Data = departments };
        }
    }
}
