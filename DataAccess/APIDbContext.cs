using Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
                
        }

        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CoffeeCompany> CoffeeCompanies { get; set; }

        public DbSet<CoffeeRating> CoffeeRating { get; set; }
    }
}
