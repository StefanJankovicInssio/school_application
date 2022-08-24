using Application.Models;
using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    public class StudentCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
