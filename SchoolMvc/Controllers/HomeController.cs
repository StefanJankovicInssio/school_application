using Application.Data;
using Application.Dtos;
using Application.Dtos.Student;
using Application.Services;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SchoolMvc.Models;
using System.Diagnostics;

namespace SchoolMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;
        private readonly IStudentService studentService;

        public HomeController(ApplicationDbContext dbContext, IUnitOfWork unitOfWork, IStudentService studentService)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
            this.studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Students(int page = 1)
        {
            ResponsePage<GetStudentDto> students = await studentService.Get(page);
            return View(students);
        }

        public async Task<IActionResult> Student(int id)
        {
            GetStudentDetailsDto student = await studentService.GetDetailsById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult StudentEdit(int id)
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> StudentEdit(int id, EditStudentDto data)
        {
            await studentService.EditById(id, data);
            return RedirectToAction("Students");

        }

        public async Task<IActionResult> StudentDelete(int id)
        {
            await studentService.DeleteById(id);
            return RedirectToAction(nameof(Students));
        }

        public IActionResult StudentAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentAdd(AddStudentDto data)
        {
            await studentService.Add(data);
            return RedirectToAction("Students");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}