using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Com.Core.Dotsafe.Domain;

namespace Com.Core.Dotsafe.Infrastructure.Data.TypeConfigurations
{
    internal class TechnoEntityTypeConfiguration : IEntityTypeConfiguration<Techno>
    {
        public void Configure(EntityTypeBuilder<Techno> builder)
        {
            builder
                .HasMany(c => c.Contributions)
                .WithOne(e => e.Techno);
        }
    }
}
