using Application;
using Application.Data;
using Application.Dtos.Student;
using Application.Models;
using Application.Services;
using Domain.Infrastructure;
using Domain.Service;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        public StudentService()
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
        }


        public async Task AddStudent(AddStudentDto student)
        {
            Student newStudent = new Student();
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Address = Address.CreateInstance(student.Address.Country, student.Address.City, student.Address.ZipCode, student.Address.Street);

            await unitOfWork.StudentRepository.Insert(newStudent);
            unitOfWork.Save();
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await dbContext.Students.FindAsync(studentId);

            await unitOfWork.StudentRepository.Delete(student.Id);
        }

        public async Task EditStudent(int studentId, EditStudentDto student)
        {
            var currentStudent = await dbContext.Students.FindAsync(studentId);

            currentStudent.FirstName = student.FirstName;
            currentStudent.LastName = student.LastName;
            currentStudent.Address = Address.CreateInstance(student.Address.Country, student.Address.City, student.Address.ZipCode, student.Address.Street);

            await unitOfWork.StudentRepository.Update(currentStudent);
            unitOfWork.Save();
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudent(int studentId)
        {
            var student = await dbContext.Students
                .Where(x => x.Id == studentId)
                .Select(x => new GetStudentDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return new ServiceResponse<GetStudentDto> { Success = false, ErrorMessage = "There is no student for this id" };
            }

            return new ServiceResponse<GetStudentDto>
            {
                Data = student
            };
        }

        public async Task<ServiceResponse<IEnumerable<GetStudentDto>>> GetStudents()
        {
            IEnumerable<GetStudentDto> students = await dbContext.Students.Select(x => new GetStudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).AsNoTracking().ToListAsync();

            return new ServiceResponse<IEnumerable<GetStudentDto>> { Data = students };
        }
    }
}
