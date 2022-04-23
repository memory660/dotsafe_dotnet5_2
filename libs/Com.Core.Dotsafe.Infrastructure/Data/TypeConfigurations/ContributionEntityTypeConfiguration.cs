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
    class ContributionEntityTypeConfiguration : IEntityTypeConfiguration<Contribution>
    {
        public void Configure(EntityTypeBuilder<Contribution> builder)
        {

            builder.HasOne(item => item.User)
            .WithMany(item => item.Contributions);

            builder.HasOne(item => item.Techno)
            .WithMany(item => item.Contributions);

            builder.HasOne(item => item.Project)
            .WithMany(item => item.Contributions);
        }
    }
}
