using Application.Dtos;
using Application.Dtos.Student;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStudentService
    {
        public Task<ResponsePage<GetStudentDto>> Get(int page, int pageSize = 4, int? courseId = null, string? firstName = null, string? lastName = null);
        public Task<GetStudentDto> GetById(int id);
        public Task<GetStudentDetailsDto> GetDetailsById(int id);
        public Task Add(AddStudentDto data);
        public Task EditById(int id, EditStudentDto data);
        public Task DeleteById(int data);
    }
}
