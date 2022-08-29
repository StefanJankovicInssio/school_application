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
        public Task<ResponsePage<GetProfessorDto>> GetProfessors(int page, int pageSize = 2, int? courseId = null);
        public Task<GetProfessorDto> GetProfessor(int professorId);
        public Task AddProfessor(AddProfessorDto professor);
        public Task EditProfessor(int professorId, EditProfessorDto professor);
        public Task DeleteProfessor(int professorId);
    }
}
