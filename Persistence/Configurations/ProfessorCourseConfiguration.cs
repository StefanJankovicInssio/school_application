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
    public class ProfessorCourseConfiguration : BaseConfiguration<ProfessorCourse>, IEntityTypeConfiguration<ProfessorCourse>
    {
        public override void Configure(EntityTypeBuilder<ProfessorCourse> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Course)
            .WithMany(p => p.ProfessorCourses)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProfessorCo_Cours");

            builder.HasOne(d => d.Professor)
            .WithMany(p => p.ProfessorCourses)
            .HasForeignKey(d => d.ProfessorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__ProfessorCo__Professor");
        }
    }
}
