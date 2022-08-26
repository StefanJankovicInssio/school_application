﻿using Application.Dtos.Course;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICourseService
    {
        public Task<ServiceResponse<IEnumerable<GetCourseDto>>> GetCourses();
        public Task<ServiceResponse<GetCourseDto>> GetCourse(int courseId);
        public Task AddCourse(AddCourseDto course);
        public Task EditCourse(int courseId, EditCourseDto course);
        public Task DeleteCourse(int courseId);
        public Task AddStudentToCourse(int studentId, int courseId);
        public Task AddProfessorToCourse(int professorId, int courseId);
    }
}