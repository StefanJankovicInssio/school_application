using Application.Data;
using Application.Models;
using Domain.Infrastructure.Repositories;
using Domain.Service;
using Domain.Service.Abstractions.Repositories;
using Domain.Service.Repositories;
using Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(
            ApplicationDbContext context,
            ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository )
        {
            this.context = context;
            this.CourseRepository = courseRepository;
            this.DepartmentRepository = departmentRepository;
            this.ProfessorRepository = professorRepository;
            this.StudentRepository = studentRepository;
        }
       
        public ApplicationDbContext context { get; }
        public ICourseRepository CourseRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IProfessorRepository ProfessorRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
