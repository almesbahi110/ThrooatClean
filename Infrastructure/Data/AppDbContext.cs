
using Microsoft.EntityFrameworkCore;

using Domain;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Stage> Stages { get; set; }
     
   


    }
}