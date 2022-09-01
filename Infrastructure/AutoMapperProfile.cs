using Application.Dtos;
using Application.Dtos.Course;
using Application.Dtos.Department;
using Application.Dtos.Professor;
using Application.Dtos.Student;
using Application.Models;
using AutoMapper;
using Domen.Models;
using Infrastructure.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, GetDepartmentDto>();
            CreateMap<AddDepartmentDto, Department>();
            CreateMap<EditDepartmentDto, Department>();
            CreateMap<Course, GetCourseDto>();
            CreateMap<AddCourseDto, Course>();
            CreateMap<EditCourseDto, Course>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<EditStudentDto, Student>()
                .AfterMap((src, dest) => 
                { dest.Address = Address.CreateInstance(src.Address.Country, src.Address.City, src.Address.ZipCode, src.Address.Street); });
            CreateMap<Student, GetStudentDto>();
            CreateMap<Student, GetStudentDetailsDto>();
            CreateMap<AddProfessorDto, Professor>();
            CreateMap<EditProfessorDto, Professor>().AfterMap((src, dest) =>
            { dest.Address = Address.CreateInstance(src.Address.Country, src.Address.City, src.Address.ZipCode, src.Address.Street); });
            CreateMap<Professor, GetStudentDto>();

            CreateMap<AddressDto, Address>()
                .ForCtorParam("Country", opt => opt.MapFrom(src => src.Country))
                .ForCtorParam("City", opt => opt.MapFrom(src => src.City))
                .ForCtorParam("Street", opt => opt.MapFrom(src => src.Street))
                .ForCtorParam("ZipCode", opt => opt.MapFrom(src => src.ZipCode));




        }


    }
}
