using Microsoft.EntityFrameworkCore;
using ReefTankTracker.Models.v1;

namespace ReefTankTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        } 

        public DbSet<UserV1> Users { get; set; }

    }
}
