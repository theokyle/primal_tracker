using System;
using Microsoft.EntityFrameworkCore;
using MODELS.Entities;
using System.Text.Json;

namespace DATA;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<User> Users { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Player> Players { get; set; }

}

