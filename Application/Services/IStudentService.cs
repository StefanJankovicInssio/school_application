﻿using Application.Dtos;
using Application.Dtos.Student;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStudentService
    {
        public Task<ResponsePage<GetStudentDto>> GetStudents(int page, int pageSize = 2, int? courseId = null);
        public Task<GetStudentDto> GetStudent(int studentId);
        public Task AddStudent(AddStudentDto student);
        public Task EditStudent(int studentId, EditStudentDto student);
        public Task DeleteStudent(int studentId);
    }
}
