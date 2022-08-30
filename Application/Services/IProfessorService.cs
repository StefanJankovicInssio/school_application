using Application.Dtos;
using Application.Dtos.Professor;
using Application.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProfessorService
    {
        public Task<ResponsePage<GetProfessorDto>> Get(int page, int pageSize = 2, int? courseId = null);
        public Task<GetProfessorDto> GetById(int professorId);
        public Task Add(AddProfessorDto professor);
        public Task EditById(int professorId, EditProfessorDto professor);
        public Task DeleteById(int professorId);
    }
}
