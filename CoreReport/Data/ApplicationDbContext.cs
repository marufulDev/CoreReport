using CoreReport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreReport.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Reporting> Reportings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1; port= 3306; user=root;password=asdf@1234;database=ejabeda_habro")
                .UseLoggerFactory(LoggerFactory.Create(b => b
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}