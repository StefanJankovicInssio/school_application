using Domain.Service.Abstractions.Repositories;
using Domain.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IProfessorCourseRepository ProfessorCourseRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task Save();
    }
}
