using front_to_back.Models;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<RecentWorkComponent> RecentWorkComponents { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryComponent> CategoryComponents { get; set; }
        public DbSet<PricingComponent> PricingComponents { get; set; }
        public DbSet<ObjectiveComponent> ObjectiveComponents { get; set; }
        public DbSet<OurPartnerComponent> OurPartnerComponents { get; set; }
    
        public DbSet<OurTeamComponent> OurTeamComponents { get; set; }

        public DbSet<ContactBannerHero> ContactBannerHeroes { get; set; }
        

    }
   
}
