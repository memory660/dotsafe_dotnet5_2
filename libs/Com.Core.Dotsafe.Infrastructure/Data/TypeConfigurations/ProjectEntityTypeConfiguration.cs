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
    internal class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasMany(c => c.Contributions)
                .WithOne(e => e.Project);
        }
    }
}
