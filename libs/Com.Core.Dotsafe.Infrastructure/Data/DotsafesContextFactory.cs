using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Infrastructure.Data
{
    public class DotsafesContextFactory : IDesignTimeDbContextFactory<DotsafesContext>
    {
        #region Public methods
        public DotsafesContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder configurationbuilder = new ConfigurationBuilder();

            configurationbuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appSettings.json"));

            IConfigurationRoot configurationRoot = configurationbuilder.Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            string connection = configurationRoot.GetConnectionString("MariaDbConnectionString");
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection));

            DotsafesContext context = new DotsafesContext(builder.Options);

            return context;
        }
        #endregion
    }
}