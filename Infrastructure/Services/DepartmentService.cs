using Application;
using Application.Data;
using Application.Dtos.Department;
using Application.Models;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public DepartmentService(IMapper mapper)
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            this.mapper = mapper;
        }

        public async Task AddDepartment(AddDepartmentDto department)
        {
            Department newDepartment = new Department();
            newDepartment = mapper.Map<Department>(department);

            await unitOfWork.DepartmentRepository.Insert(newDepartment);
            await unitOfWork.Save();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var department = await unitOfWork.DepartmentRepository.GetById(departmentId);

            await unitOfWork.DepartmentRepository.Delete(department.Id);
            await unitOfWork.Save();
        }

        public async Task EditDepartment(int departmentId, EditDepartmentDto department)
        {
            Department currentDepartment = await unitOfWork.DepartmentRepository.GetById(departmentId);
            mapper.Map<EditDepartmentDto, Department>(department, currentDepartment);

            await unitOfWork.DepartmentRepository.Update(currentDepartment);
            await unitOfWork.Save();
        }

        public async Task<GetDepartmentDto> GetDepartmentById(int departmentId)
        {
            var department = await dbContext.Departments
                .Where(x => x.Id == departmentId)
                .ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<GetDepartmentDto> GetDepartmentByName(string departmentName) 
        {
            var department = await dbContext.Departments
               .Where(x => x.Name == departmentName)
               .ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetDepartments()
        {
            return await dbContext.Departments.ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).ToListAsync();
        }


    }
}
