using Application.Dtos.Department;
using Application.Services;
using Infrastructure.Dtos.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Xml.Linq;

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

        [HttpGet, Authorize(Roles = "admin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                Log.Information("Get all departments");
                return Ok(await depertmentService.Get());
            }
            catch(Exception ex)
            {
                Log.Fatal("Error", ex.Message);
                throw new Exception("Server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ById(int id)
        {
            try
            {
                Log.Information("Get department by id");
                return Ok(await depertmentService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id}", id, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpGet("byName/{name}")]
        public async Task<IActionResult> ByName(string name)
        {
            try
            {
                Log.Information("Get department by name");
                return Ok(await depertmentService.GetByName(name));
            }
            catch (Exception ex)
            {
                Log.Fatal("Argument {@name}", name, ex.Message);
                throw new Exception("Server Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDepartmentDto data)
        {
            //return await ExecuteMethode(() => depertmentService.Add(data));
            try
            {
                Log.Information("Add department");
                await depertmentService.Add(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Sent object {@data}", data, ex.Message);
                throw new Exception("Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditDepartmentDto data)
        {
            try
            {
                Log.Information("Edit department");
                await depertmentService.EditById(id, data);
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
                Log.Information("Delete department");
                await depertmentService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Fatal("Id {@id} is not exist", id, ex.Message);
                throw new Exception("Server Error");
            }

        }
        //private async Task<IActionResult> ExecuteMethod(Action action)
        //{
        //    try
        //    {
        //        Log.Information(action.GetType().Name);

        //        action();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
                
        //        Log.Fatal("Error {$action}", ex.Message);

        //        throw new Exception("Server Error");
        //    }
        //}
    }
}
