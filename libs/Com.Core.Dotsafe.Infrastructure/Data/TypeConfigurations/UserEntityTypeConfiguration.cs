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
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(c => c.Contributions)
                .WithOne(e => e.User);
        }
    }
}

// accdb
// RtGh10!ljg