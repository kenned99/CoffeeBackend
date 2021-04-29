﻿using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckIn> CheckIn { get; set; }
        public DbSet<Friend> Friends { get; set; }

    }
}
