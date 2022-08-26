using Application;
using Application.Data;
using Application.Dtos.Course;
using Application.Models;
using Application.Services;
using Domain.Infrastructure;
using Domain.Service;
using Domain.Service.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        public CourseService()
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
        }
        public async Task AddCourse(AddCourseDto course)
        {
            Course newCourse = new Course();
            newCourse.Name = course.Name;

            await unitOfWork.CourseRepository.Insert(newCourse);
            unitOfWork.Save();
        }

        public async Task DeleteCourse(int courseId)
        {
            var course = await dbContext.Courses.FindAsync(courseId);

            await unitOfWork.CourseRepository.Delete(course.Id);
        }

        public async Task EditCourse(int courseId, EditCourseDto course)
        {
            var currentCourse = await dbContext.Courses.FindAsync(courseId);

            currentCourse.Name = course.Name;

            await unitOfWork.CourseRepository.Update(currentCourse);
            unitOfWork.Save();
        }

        public async Task<ServiceResponse<GetCourseDto>> GetCourse(int courseId)
        {
            var course = await dbContext.Courses
                .Where(x => x.Id == courseId)
                .Select(x => new GetCourseDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();

            if (course == null)
            {
                return new ServiceResponse<GetCourseDto> { Success = false, ErrorMessage = "There is no course for this id" };
            }

            return new ServiceResponse<GetCourseDto>
            {
                Data = course
            };
        }

        public async Task<ServiceResponse<IEnumerable<GetCourseDto>>> GetCourses()
        {
            IEnumerable<GetCourseDto> courses = await dbContext.Courses.Select(x => new GetCourseDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            }).AsNoTracking().ToListAsync();

            return new ServiceResponse<IEnumerable<GetCourseDto>> { Data = courses };
        }

        public async Task AddProfessorToCourse(int professorId, int courseId)
        {
            await unitOfWork.CourseRepository.AddProfessorToCourse(professorId, courseId);
        }

        public async Task AddStudentToCourse(int studentId, int courseId)
        {
            await unitOfWork.CourseRepository.AddStudentToCourse(studentId, courseId);
        }
    }
}
