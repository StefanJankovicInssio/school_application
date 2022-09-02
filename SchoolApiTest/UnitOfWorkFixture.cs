using Application.Data;
using Application.Models;
using AutoMapper;
using Domain.Infrastructure;
using Domain.Service;
using Domain.Service.Abstractions.Repositories;
using Domain.Service.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest
{
    public class UnitOfWorkFixture : IDisposable
    {
        public UnitOfWorkFixture()
        {
            dbContext = new DatabaseFixture().dbContext;

            unitOfWork = new UnitOfWork(
            dbContext,
            new CourseRepository(dbContext),
            new DepartmentRepository(dbContext),
            new ProfessorRepository(dbContext),
            new StudentRepository(dbContext)
            );
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public ApplicationDbContext dbContext { get; private set; }
        public IUnitOfWork unitOfWork { get; }


    }
}

