using Microsoft.EntityFrameworkCore;
using SavePointAPI.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace SavePointAPI.Data
{
    public class GamesDbContext : DbContext
    {
        // Iniatialize constructor for DB connection
        // Inhert options from parent DbContext
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options) { }

        // Set table for game information
        public DbSet<Games> Games { get; set; }

        // Set table for registered users
        public DbSet<User> Users { get; set; }

        // Set table for profile photos
        public DbSet<Photo> ProfilePhotos { get; set; }
    }
}