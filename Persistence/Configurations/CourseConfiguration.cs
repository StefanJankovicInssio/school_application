using Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CourseConfiguration : BaseConfiguration<Course>, IEntityTypeConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(64);

            builder.HasOne(d => d.Department)
            .WithMany(p => p.Courses)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Course_Department");

            builder.HasIndex(c => c.Code).IsUnique();

        }
    }
}
