using Microsoft.EntityFrameworkCore;

namespace Destination.Models
{
  public class DestinationContext : DbContext
  {
    public DestinationContext(DbContextOptions<DestinationContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews {get; set;} 
  }
}