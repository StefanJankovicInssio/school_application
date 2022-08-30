using Application.Dtos.Student;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> Get(int page)
        {
            return Ok(await studentService.Get(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> ById(int id)
        {
            return Ok(await studentService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddStudentDto data)
        {
            await studentService.Add(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditStudentDto data)
        {
            await studentService.EditById(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await studentService.DeleteById(id);
            return Ok();
        }
    }
}
