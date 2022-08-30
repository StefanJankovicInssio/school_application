using Application.Dtos.Department;
using Application.Services;
using Infrastructure.Dtos.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService depertmentService;
        private readonly ILogger<DepartmentController> logger;

        public DepartmentController(IDepartmentService depertmentService, ILogger<DepartmentController> logger)
        {
            this.depertmentService = depertmentService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> Get()
        {
            logger.LogInformation("Get all departments");
            return Ok(await depertmentService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDto>> ById(int id)
        {
            return Ok(await depertmentService.GetById(id));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<GetDepartmentDto>> ByName(string name)
        {
            return Ok(await depertmentService.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddDepartmentDto data)
        {
            await depertmentService.Add(data);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditDepartmentDto data)
        {
            await depertmentService.EditById(id, data);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await depertmentService.DeleteById(id);
            return Ok();
        }

    }
}
