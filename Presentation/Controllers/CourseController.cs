using Application.Dtos.Course;
using Application.Dtos.Professor;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> Get(int page)
        {
            try
            {
                Log.Information("Get courses per page");
                return Ok(await courseService.Get(page));
            }
            catch (Exception ex)
            {
                Log.Fatal("Page {@page}", page, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ById(int id)
        {
            try
            {
                Log.Information("Get course by id");
                return Ok(await courseService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id}",id, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCourseDto data)
        {
            try
            {
                Log.Information("Add course");
                await courseService.Add(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCourseDto data)
        {
            try
            {
                Log.Information("Edit course");
                await courseService.EditById(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} Sent object {@data}", id, data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Log.Information("Delete course");
                await courseService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} is not exist", id, ex.Message);
                throw new Exception("Server Error");
            } 
        }

        [HttpPost("studentToCourse")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentToCourseDto data)
        {
            try
            {
                Log.Information("Add student to course");
                await courseService.AddStudentToCourse(data.studentId, data.courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPost("professorToCourse")]
        public async Task<IActionResult> AddProfessor([FromBody] AddProfessorToCourseDto data)
        {
            try
            {
                Log.Information("Add professor to course");
                await courseService.AddProfessorToCourse(data.professorId, data.courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

    }
}
