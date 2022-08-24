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
        public Grade Grade { get; set; } = Grade.five;
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    public enum Grade
    {
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
    }

}
