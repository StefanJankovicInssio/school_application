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
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartmentService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Add(AddDepartmentDto data)
        {
            Department newDepartment = new Department();
            newDepartment = mapper.Map<Department>(data);

            await unitOfWork.DepartmentRepository.Insert(newDepartment);
            await unitOfWork.Save();
        }

        public async Task DeleteById(int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetById(id);

            await unitOfWork.DepartmentRepository.Delete(department.Id);
            await unitOfWork.Save();
        }

        public async Task EditById(int id, EditDepartmentDto data)
        {
            Department currentDepartment = await unitOfWork.DepartmentRepository.GetById(id);
            mapper.Map<EditDepartmentDto, Department>(data, currentDepartment);

            await unitOfWork.DepartmentRepository.Update(currentDepartment);
            await unitOfWork.Save();
        }

        public async Task<GetDepartmentDto> GetById(int id)
        {
            var department = await dbContext.Departments
                .Where(x => x.Id == id)
                .ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<GetDepartmentDto> GetByName(string name) 
        {
            var department = await dbContext.Departments
               .Where(x => x.Name == name)
               .ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<IEnumerable<GetDepartmentDto>> Get()
        {
            return await dbContext.Departments.ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).ToListAsync();
        }


    }
}
