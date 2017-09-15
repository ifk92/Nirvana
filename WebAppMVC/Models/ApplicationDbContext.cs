using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace WebAppMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Categorie> Categories { get; set; }


        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}