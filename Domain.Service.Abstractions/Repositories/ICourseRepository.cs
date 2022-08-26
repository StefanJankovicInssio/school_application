using Application.Models;
using Domain.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Abstractions.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {

        public Task AddStudentToCourse(int studentId, int courseId);
        public Task AddProfessorToCourse(int professorId, int courseId);
    }
}
