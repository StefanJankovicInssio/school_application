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

        public void AddStudentToCourse(int studentId, int courseId)
        {
            context.StudentCourses.Add(new StudentCourse { StudentId = studentId, CourseId = courseId });
        }

        public void AddProfessorToCourse(int professorId, int courseId)
        {
            context.ProfessorCourses.Add(new ProfessorCourse { ProfessorId = professorId, CourseId = courseId });
        }

    }
}
