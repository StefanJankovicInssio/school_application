using Application.Dtos.Professor;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService studentService;

        public ProfessorController(IProfessorService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<IEnumerable<GetProfessorDto>>> Get(int page)
        {
            return Ok(await studentService.Get(page));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProfessorDto>> ById(int id)
        {
            return Ok(await studentService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddProfessorDto data)
        {
            await studentService.Add(data);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditProfessorDto data)
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
