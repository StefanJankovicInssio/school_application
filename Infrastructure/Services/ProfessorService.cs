using Application.Data;
using Application.Dtos.Professor;
using Application.Models;
using Application;
using Domain.Infrastructure;
using Domain.Service;
using Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ProfessorService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        public ProfessorService()
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
        }


        public async Task AddProfessor(AddProfessorDto professor)
        {
            Professor newProfessor = new Professor();
            newProfessor.FirstName = professor.FirstName;
            newProfessor.LastName = professor.LastName;
            newProfessor.Address = Address.CreateInstance(
                professor.Address.Country, professor.Address.City, professor.Address.ZipCode, professor.Address.Street
                );

            await unitOfWork.ProfessorRepository.Insert(newProfessor);
            unitOfWork.Save();
        }

        public async Task DeleteProfessor(int professorId)
        {
            var professor = await dbContext.Professors.FindAsync(professorId);

            await unitOfWork.ProfessorRepository.Delete(professor.Id);
        }

        public async Task EditProfessor(int professorId, EditProfessorDto professor)
        {
            var currentProfessor = await dbContext.Professors.FindAsync(professorId);

            currentProfessor.FirstName = professor.FirstName;
            currentProfessor.LastName = professor.LastName;
            currentProfessor.Address = Address.CreateInstance(
                professor.Address.Country, professor.Address.City, professor.Address.ZipCode, professor.Address.Street
                );

            await unitOfWork.ProfessorRepository.Update(currentProfessor);
            unitOfWork.Save();
        }

        public async Task<ServiceResponse<GetProfessorDto>> GetProfessor(int professorId)
        {
            var professor = await dbContext.Professors
                .Where(x => x.Id == professorId)
                .Select(x => new GetProfessorDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .FirstOrDefaultAsync();

            if (professor == null)
            {
                return new ServiceResponse<GetProfessorDto> { Success = false, ErrorMessage = "There is no professor for this id" };
            }

            return new ServiceResponse<GetProfessorDto>
            {
                Data = professor
            };
        }

        public async Task<ServiceResponse<IEnumerable<GetProfessorDto>>> GetProfessors()
        {
            IEnumerable<GetProfessorDto> professors = await dbContext.Professors.Select(x => new GetProfessorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).AsNoTracking().ToListAsync();

            return new ServiceResponse<IEnumerable<GetProfessorDto>> { Data = professors };
        }

    }
}
