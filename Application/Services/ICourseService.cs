using Application.Dtos;
using Application.Dtos.Course;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICourseService
    {
        public Task<ResponsePage<GetCourseDto>> Get(int page, int pageSize = 2);
        public Task<GetCourseDto> GetById(int id);
        public Task Add(AddCourseDto data);
        public Task EditById(int id, EditCourseDto data);
        public Task DeleteById(int id);
        public Task AddStudentToCourse(int studentId, int courseId);
        public Task AddProfessorToCourse(int professorId, int courseId);
    }
}
