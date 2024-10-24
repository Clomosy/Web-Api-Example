namespace ClomosyWebApiExample.Data
{
    using Microsoft.EntityFrameworkCore;
    using global::ClomosyWebApiExample.Models;

    namespace ClomosyWebApiExample.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; } 
        }
    }

}
