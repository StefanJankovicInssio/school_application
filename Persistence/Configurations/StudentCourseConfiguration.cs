using Application.Models;
using Domen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class StudentCourseConfiguration : BaseConfiguration<StudentCourse>, IEntityTypeConfiguration<StudentCourse>
    {
        public override void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Course)
            .WithMany(p => p.StudentCourses)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_StudentCo_Cours");

            builder.HasOne(d => d.Student)
            .WithMany(p => p.StudentCourses)
            .HasForeignKey(d => d.StudentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__StudentCo__Student");
        }
    }
}
