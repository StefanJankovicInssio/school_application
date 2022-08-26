using Application.Dtos.Professor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProfessorService
    {
        public Task<ServiceResponse<IEnumerable<GetProfessorDto>>> GetProfessors();
        public Task<ServiceResponse<GetProfessorDto>> GetProfessor(int professorId);
        public Task AddProfessor(AddProfessorDto professor);
        public Task EditProfessor(int professorId, EditProfessorDto professor);
        public Task DeleteProfessor(int professorId);
    }
}
