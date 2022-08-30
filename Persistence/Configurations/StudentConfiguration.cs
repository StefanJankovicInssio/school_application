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
    public class StudentConfiguration : BaseConfiguration<Student>, IEntityTypeConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(64);
            builder.Property(e => e.Index).IsRequired().HasMaxLength(64);

            builder.OwnsOne(e => e.Address, sb =>
            {
                sb.Property(e => e.Country).IsRequired().HasMaxLength(64);
                sb.Property(e => e.City).IsRequired().HasMaxLength(64);
                sb.Property(e => e.ZipCode).IsRequired().HasMaxLength(64);
                sb.Property(e => e.Street).IsRequired().HasMaxLength(128);
            });
        }
    }
}
