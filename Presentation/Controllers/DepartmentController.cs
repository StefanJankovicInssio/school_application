using Application.Dtos.Department;
using Application.Services;
using Infrastructure.Dtos.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService depertmentService;

        public DepartmentController(IDepartmentService depertmentService)
        {
            this.depertmentService = depertmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentDto>>> Get()
        {
            return Ok(await depertmentService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDto>> ById(int id)
        {
            try
            {
                Log.Information("Get department by id");

                return Ok(await depertmentService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Argument is not valid", ex.Message);

                throw new Exception("Server Error");
            }
        }

        [HttpGet("byName/{name}")]
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

        [HttpPut("{id}")]
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
