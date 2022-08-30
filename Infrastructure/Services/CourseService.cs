using Application;
using Application.Data;
using Application.Dtos;
using Application.Dtos.Course;
using Application.Models;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public CourseService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Add(AddCourseDto data)
        {
            Course newCourse = new Course();
            newCourse = mapper.Map<Course>(data);

            await unitOfWork.CourseRepository.Insert(newCourse);
            await unitOfWork.Save();
        }

        public async Task DeleteById(int id)
        {
            var course = await unitOfWork.CourseRepository.GetById(id);

            await unitOfWork.CourseRepository.Delete(course.Id);
        }

        public async Task EditById(int id, EditCourseDto data)
        {
            var currentCourse = await unitOfWork.CourseRepository.GetById(id);

            mapper.Map<EditCourseDto, Course>(data, currentCourse);

            await unitOfWork.CourseRepository.Update(currentCourse);
            await unitOfWork.Save();
        }

        public async Task<GetCourseDto> GetById(int id)
        {
            var course = await dbContext.Courses
                .Where(x => x.Id == id)
                .ProjectTo<GetCourseDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return course;
        }

        public async Task<ResponsePage<GetCourseDto>> Get(int page, int pageSize = 2)
        {
            var pageCount = Math.Ceiling((decimal)dbContext.Courses.Count() / pageSize);

            IEnumerable<GetCourseDto> courses = await dbContext.Courses.ProjectTo<GetCourseDto>(mapper.ConfigurationProvider)
                .Skip((page - 1) * (int)(pageSize))
                .Take((int)pageSize)
                .ToListAsync();

            return new ResponsePage<GetCourseDto> { Result = courses, CurrentPage = page, Pages = (int)pageCount };

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
