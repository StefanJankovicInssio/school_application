using Application.Data;
using Application.Services;
using Domain.Infrastructure;
using Domain.Service;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "appdb")
            .Options;

            dbContext = new ApplicationDbContext(dbContextOptions);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public ApplicationDbContext dbContext { get; private set; }

    }
}
