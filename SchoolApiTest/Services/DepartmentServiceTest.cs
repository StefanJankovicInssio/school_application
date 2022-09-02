using Application.Data;
using Application.Dtos.Student;
using Infrastructure.Dtos.Department;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest.Services
{
    [Collection("Services")]
    public class DepartmentServiceTest : IClassFixture<UnitOfWorkFixture>
    {
        UnitOfWorkFixture fixture;
        private readonly ServiceCollection serviceCollection;

        public DepartmentServiceTest(UnitOfWorkFixture fixture, ServiceCollection serviceCollection)
        {
            this.fixture = fixture;
            this.serviceCollection = serviceCollection;
        }

        [Fact]
        public async Task AddDepartmentTest()
        {
            var departmentService = new DepartmentService(fixture.dbContext, fixture.unitOfWork, serviceCollection.mapper);

            AddDepartmentDto data = new AddDepartmentDto
            {
                Name = "Test"
            };

            await departmentService.Add(data);

            Assert.Equal(1, fixture.dbContext.Departments.Count());
        }

        [Fact]
        public async Task GetDepartmentById()
        {
            var departmentService = new DepartmentService(fixture.dbContext, fixture.unitOfWork, serviceCollection.mapper);

            AddDepartmentDto data = new AddDepartmentDto
            {
                Name = "Test"
            };

            await departmentService.Add(data);

            var department = (await departmentService.Get()).FirstOrDefault();

            Assert.Equal("Test", department.Name);
        }

    }
}
