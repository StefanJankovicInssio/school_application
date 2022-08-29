using Application;
using Application.Data;
using Application.Dtos;
using Application.Dtos.Professor;
using Application.Dtos.Student;
using Application.Models;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Infrastructure;
using Domain.Service;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = Domen.Models.Address;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IMapper mapper)
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            this.mapper = mapper;
        }


        public async Task AddStudent(AddStudentDto student)
        {
            Student newStudent = new Student();
            newStudent = mapper.Map<Student>(student);

            await unitOfWork.StudentRepository.Insert(newStudent);
            await unitOfWork.Save();
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await unitOfWork.StudentRepository.GetById(studentId);

            await unitOfWork.StudentRepository.Delete(student.Id);
            await unitOfWork.Save();

        }

        public async Task EditStudent(int studentId, EditStudentDto student)
        {
            var currentStudent = await unitOfWork.StudentRepository.GetById(studentId);

            currentStudent = mapper.Map<Student>(student);

            await unitOfWork.StudentRepository.Update(currentStudent);
            await unitOfWork.Save();
        }

        public async Task<GetStudentDto> GetStudent(int studentId)
        {
            var student = await dbContext.Students
                .Where(x => x.Id == studentId)
                .ProjectTo<GetStudentDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<ResponsePage<GetStudentDto>> GetStudents(int page, int pageSize = 2, int? courseId = null)
        {
            var query = dbContext.Students.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.StudentCourses.Any(y=>y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)query.Count() / pageSize);

            IEnumerable<GetStudentDto> students = await query.ProjectTo<GetStudentDto>(mapper.ConfigurationProvider)
            .Skip((page - 1) * (int)(pageSize))
            .Take((int)pageSize)
            .ToListAsync();

            var reponse = new ResponsePage<GetStudentDto> { Result = students, CurrentPage = page, Pages = (int)pageCount };
            return reponse;
        }
    }
}
