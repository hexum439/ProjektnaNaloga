using Microsoft.EntityFrameworkCore;
using SecondHand.Models;
using System.Drawing;

namespace SecondHand.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Oblacila> Oblacilas { get; set; }
        public DbSet<Obutev> Obutevs { get; set; }
        public DbSet<KategorijeCevlji> KategorijeCevljis { get; set; }
        public DbSet<KategorijeOblacila> KategorijeOblacilas { get; set; }
    }
}
