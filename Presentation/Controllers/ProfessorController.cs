using Application.Dtos.Professor;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> Get(int page)
        {
            try
            {
                Log.Information("Get professors per page");
                return Ok(await professorService.Get(page));
            }
            catch (Exception ex)
            {
                Log.Fatal("Page {@page}",page, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ById(int id)
        {
            try
            {
                Log.Information("Get professor by id");
                return Ok(await professorService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} is not exist", id, ex.Message);
                throw new Exception("Server Error");
            };
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProfessorDto data)
        {
            try
            {
                Log.Information("Add professor");
                await professorService.Add(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditProfessorDto data)
        {
            try
            {
                Log.Information("Edit professor");
                await professorService.EditById(id, data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} Sent object {@data}",id, data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Log.Information("Delete professor");
                await professorService.DeleteById(id);
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
