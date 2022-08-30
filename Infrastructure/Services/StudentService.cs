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

        public StudentService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task Add(AddStudentDto data)
        {
            Student newStudent = new Student();
            newStudent = mapper.Map<Student>(data);

            await unitOfWork.StudentRepository.Insert(newStudent);
            await unitOfWork.Save();
        }

        public async Task DeleteById(int id)
        {
            var student = await unitOfWork.StudentRepository.GetById(id);

            await unitOfWork.StudentRepository.Delete(student.Id);
            await unitOfWork.Save();

        }

        public async Task EditById(int id, EditStudentDto data)
        {
            var currentStudent = await unitOfWork.StudentRepository.GetById(id);

            mapper.Map<EditStudentDto, Student>(data, currentStudent);

            await unitOfWork.StudentRepository.Update(currentStudent);
            await unitOfWork.Save();
        }

        public async Task<GetStudentDto> GetById(int id)
        {
            var student = await dbContext.Students
                .Where(x => x.Id == id)
                .ProjectTo<GetStudentDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<ResponsePage<GetStudentDto>> Get(int page, int pageSize = 2, int? courseId = null, string? firstName = null, string? lastName = null)
        {
            var query = dbContext.Students.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.StudentCourses.Any(y=>y.CourseId == courseId));
            }

            if (String.IsNullOrWhiteSpace(firstName) == false)
            {
                query = query.Where(x => x.FirstName == firstName);
            }

            if (String.IsNullOrWhiteSpace(lastName) == false)
            {
                query = query.Where(x => x.LastName == lastName);
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
