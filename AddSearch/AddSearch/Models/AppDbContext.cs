using Microsoft.EntityFrameworkCore;

namespace AddSearch.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        // DbSet represents the Student table
        public DbSet<StudentDetails> StudentTable { get; set; }
    }
}
