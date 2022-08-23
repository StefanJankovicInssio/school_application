using Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Models;

namespace Persistence.Configurations
{
    public class ProfessorConfiguration : BaseConfiguration<Professor>, IEntityTypeConfiguration<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> builder)
        {

            base.Configure(builder);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(64);

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
