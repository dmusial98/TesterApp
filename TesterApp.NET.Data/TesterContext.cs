using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TesterApp.NET.Data
{
    public class TesterContext : DbContext
    {
        public TesterContext(DbContextOptions<TesterContext> options)
            : base(options)
        {
        }

        public DbSet<Tester> Testers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Bug> Bugs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=TesterAppData")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Transaction.Name },
                    LogLevel.Information)
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name, },
                //    LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}
