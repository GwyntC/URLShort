using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace URLShort.Models
{

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):IdentityDbContext<ApplicationUser>(options)//ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<URLModel> Urls { get; set; }
       // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.Entity<URLModel>().ToTable("URLS");
           // builder.Entity<Appli>
        }
    }
   
}
