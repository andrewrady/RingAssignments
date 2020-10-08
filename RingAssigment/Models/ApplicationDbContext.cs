using Microsoft.EntityFrameworkCore;

namespace RingAssigment.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
                
         public DbSet<Ring> Ring { get; set; }      
    }
}
