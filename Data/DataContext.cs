using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReefTankTracker.Models.v1;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ReefTankTracker.Data
{
    public class DataContext : IdentityUserContext <IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        } 

        public DbSet<UserModelV1> Users { get; set; }
        public DbSet<ReefTankModelV1> ReefTanks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
