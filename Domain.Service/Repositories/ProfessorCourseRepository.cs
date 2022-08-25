using Application.Data;
using Application.Models;
using Domain.Infrastructure.Repositories;
using Domain.Service.Abstractions.Repositories;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Repositories
{
    public class ProfessorCourseRepository : GenericRepository<ProfessorCourse>, IProfessorCourseRepository
    {
        public ProfessorCourseRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
