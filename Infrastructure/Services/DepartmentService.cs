using Application.Services;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DepartmentService : IDepertmentService
    {
        private readonly UnitOfWork unitOfWork;

        public DepartmentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Application.Models.Department> All()
        {
            return unitOfWork.DepartmentRepository.Get();
        }
    }
}
