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
using Application.Services;
using Application.Dtos.Student;
using Application.Dtos;
using Address = Domen.Models.Address;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Infrastructure.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProfessorService(IMapper mapper)
        {
            dbContext = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(dbContext);
            this.mapper = mapper;
        }


        public async Task AddProfessor(AddProfessorDto professor)
        {
            Professor newProfessor = new Professor();
            newProfessor = mapper.Map<Professor>(professor);

            await unitOfWork.ProfessorRepository.Insert(newProfessor);
            await unitOfWork.Save();
        }

        public async Task DeleteProfessor(int professorId)
        {
            var professor = await unitOfWork.ProfessorRepository.GetById(professorId);

            await unitOfWork.ProfessorRepository.Delete(professor.Id);
            await unitOfWork.Save();
        }

        public async Task EditProfessor(int professorId, EditProfessorDto professor)
        {
            var currentProfessor = await unitOfWork.ProfessorRepository.GetById(professorId);

            currentProfessor = mapper.Map<Professor>(professor);

            await unitOfWork.ProfessorRepository.Update(currentProfessor);
            await unitOfWork.Save();
        }

        public async Task<GetProfessorDto> GetProfessor(int professorId)
        {
            var professor = await dbContext.Professors
                .Where(x => x.Id == professorId)
                .ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return professor;
        }

        public async Task<ResponsePage<GetProfessorDto>> GetProfessors(int page, int pageSize = 2, int? courseId = null)
        {
            var query = dbContext.Professors.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.ProfessorCourses.Any(y => y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)query.Count() / pageSize);

            IEnumerable<GetProfessorDto> professors = await query.ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider)
            .Skip((page - 1) * (int)(pageSize))
            .Take((int)pageSize)
            .ToListAsync();

            var reponse = new ResponsePage<GetProfessorDto> { Result = professors, CurrentPage = page, Pages = (int)pageCount };
            return reponse;
        }

    }
}
