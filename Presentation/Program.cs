using Application.Models;
using Application.Services;
using Domain.Infrastructure;
using Domen.Models;
using Infrastructure.Services;

public class Program
{
    //private readonly IDepertmentService depertmentService;

    //public Program(IDepertmentService depertmentService)
    //{
    //    this.depertmentService = depertmentService;
    //}
    public static void Main()
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Application.Data.ApplicationDbContext());

        //var departments = unitOfWork.DepartmentRepository;

        //unitOfWork.CourseRepository.AddStudentToCourse(1, 3);

        //unitOfWork.StudentCourseRepository.Delete(3);
        //unitOfWork.Save();

        DepartmentService departmentService = new DepartmentService(unitOfWork);
        IEnumerable<Department> departments = departmentService.All();

        foreach(var d in departments)
        {
            Console.WriteLine(d.ToString());
        }
    }

}