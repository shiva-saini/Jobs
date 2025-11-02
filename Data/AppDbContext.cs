using Jobs.Models;
using Microsoft.EntityFrameworkCore;



namespace Jobs.Data
{
   
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<Company> Companies { get; set; }
            public DbSet<AppliedJob> AppliedJobs { get; set; }

    }
    

}
