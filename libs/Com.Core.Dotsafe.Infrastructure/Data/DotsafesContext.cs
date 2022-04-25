
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Core.Dotsafe.Domain;
using Com.Core.Dotsafe.Infrastructure.Data.TypeConfigurations;
using Com.Core.Dotsafe.Framework;

namespace Com.Core.Dotsafe.Infrastructure.Data
{
    public class DotsafesContext : DbContext, IUnitOfWork
    {
        #region Constructors
        public DotsafesContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        public DotsafesContext() : base() { }
        #endregion

        #region Internal methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TechnoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContributionEntityTypeConfiguration());

        }
        #endregion

        #region Properties
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Techno> Technos { get; set; }

        public DbSet<Contribution> Contributions { get; set; }
        #endregion
    }
}