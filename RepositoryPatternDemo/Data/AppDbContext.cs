using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Models;
using System.Collections.Generic;

namespace RepositoryPatternDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
