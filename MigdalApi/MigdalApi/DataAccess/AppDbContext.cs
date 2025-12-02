using Microsoft.EntityFrameworkCore;
using MigdalApi.Models;
using System.Collections.Generic;

namespace MigdalApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; } = null!;
    }
}
