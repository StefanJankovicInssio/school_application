using Application.Data;
using Application.Dtos;
using Application.Dtos.Course;
using Application.Dtos.Department;
using Application.Dtos.Student;
using Application.Models;
using Application.Services;
using AutoMapper;
using Domain.Infrastructure;
using Domain.Service;
using Domain.Service.Abstractions.Repositories;
using Domain.Service.Repositories;
using Infrastructure;
using Infrastructure.Dtos.Department;
using Infrastructure.Services;

ApplicationDbContext context = new ApplicationDbContext();
IUnitOfWork unitOfWork = new UnitOfWork(context);

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

IMapper mapper = config.CreateMapper();

IStudentService studentService = new StudentService(mapper);
ICourseService courseService = new CourseService(mapper);

AddStudentDto data = new AddStudentDto()
{
    FirstName = "Marko",
    LastName = "Markovic",
    Address = new Address { Country = "Srbija", City = "Lazarevac", ZipCode = "11500", Street = "Jaokima Vujic 19A" }

};
await studentService.AddStudent(data);


