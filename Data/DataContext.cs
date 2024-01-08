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

        public DbSet<ReefTankModelV1> ReefTanks { get; set; }
        public DbSet<ParameterModelV1> Parameters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReefTankModelV1>().HasOne<IdentityUser>().WithMany().HasForeignKey(e => e.UserId);
            builder.Entity<ParameterModelV1>().HasOne<IdentityUser>().WithMany().HasForeignKey(e => e.UserId);
            base.OnModelCreating(builder);
        }

    }
}
