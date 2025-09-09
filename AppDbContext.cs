using ClickerGame.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClickerGame.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}
