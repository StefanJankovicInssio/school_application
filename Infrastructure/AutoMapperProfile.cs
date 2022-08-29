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
            CreateMap<EditStudentDto, Student>();
            CreateMap<Student, GetStudentDto>();
            CreateMap<AddProfessorDto, Professor>();
            CreateMap<EditProfessorDto, Professor>();
            CreateMap<Professor, GetStudentDto>();
        }
    }
}
