using Application.Data;
using Application.Models;
using Domain.Infrastructure.Repositories;
using Domain.Service.Abstractions.Repositories;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task AddProfessorToCourse(int professorId, int courseId)
        {
            await context.ProfessorCourses.AddAsync(new ProfessorCourse { ProfessorId = professorId, CourseId = courseId });
        }

        public async Task AddStudentToCourse(int studentId, int courseId)
        {
            await context.StudentCourses.AddAsync(new StudentCourse { StudentId = studentId, CourseId = courseId });
        }
    }
}
