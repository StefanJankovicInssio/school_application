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
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
