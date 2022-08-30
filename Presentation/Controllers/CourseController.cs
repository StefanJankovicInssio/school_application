using Application.Dtos.Course;
using Application.Dtos.Professor;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> Get(int page)
        {
            return Ok(await courseService.Get(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseDto>> ById(int id)
        {
            return Ok(await courseService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddCourseDto data)
        {
            await courseService.Add(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditCourseDto data)
        {
            await courseService.EditById(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await courseService.DeleteById(id);
            return Ok();
        }

        [HttpPost("studentToCourse")]
        public async Task<ActionResult> AddStudent([FromBody] AddStudentToCourseDto data)
        {
            await courseService.AddStudentToCourse(data.studentId, data.courseId);
            return Ok();
        }

        [HttpPost("professorToCourse")]
        public async Task<ActionResult> AddProfessor([FromBody] AddProfessorToCourseDto data)
        {
            await courseService.AddStudentToCourse(data.professorId, data.courseId);
            return Ok();
        }

    }
}
