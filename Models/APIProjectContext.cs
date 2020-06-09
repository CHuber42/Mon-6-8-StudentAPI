using Microsoft.EntityFrameworkCore;

namespace APIProject.Models
{
  public class APIProjectContext : DbContext
  {
    public APIProjectContext(DbContextOptions<APIProjectContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews {get; set;} 
  }
}