using Application.Dtos.Student;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> Get(int page)
        {
            try
            {
                Log.Information("Get students per page");
                return Ok(await studentService.Get(page));
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
                Log.Information("Get student by id");
                return Ok(await studentService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id}", id, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStudentDto data)
        {
            try
            {
                Log.Information("Add student");
                await studentService.Add(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditStudentDto data)
        {
            try
            {
                Log.Information("Edit student");
                await studentService.EditById(id, data);
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
                Log.Information("Delete student");
                await studentService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} is not exist", id, ex.Message);
                throw new Exception("Server Error");
            }
        }

    }
}
