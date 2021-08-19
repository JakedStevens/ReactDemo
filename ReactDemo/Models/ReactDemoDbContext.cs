using Microsoft.EntityFrameworkCore;

namespace ReactDemo.Models
{
    public class ReactDemoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.;Database=ReactDemo;Trusted_Connection=True");

        public DbSet<Comment> Comment { get; set; }
    }
}
