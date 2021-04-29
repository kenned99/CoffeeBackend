using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<Coffee> UserTokens { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
