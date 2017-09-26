using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace WebAppMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .HasRequired(f => f.Post).WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}