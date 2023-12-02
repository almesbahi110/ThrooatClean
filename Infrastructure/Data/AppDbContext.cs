
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Stage> Stages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProcessStages> ProcessStagess { get; set; }
        public DbSet<ProcessRequest> ProcessRequests { get; set; }
        public DbSet<Process> Processs { get; set; }
     
   


    }
}