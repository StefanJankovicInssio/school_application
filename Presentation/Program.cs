using Application.Services;
using Infrastructure.Dtos.Department;
using Infrastructure.Services;

IDepertmentService depertmentService = new DepartmentService();

AddDepartmentDto data = new AddDepartmentDto()
{
    Name = "NRT"
};

await depertmentService.AddDepartment(data);