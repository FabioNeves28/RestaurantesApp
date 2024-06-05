using Microsoft.EntityFrameworkCore;
using RestaurantesApp.Models;

namespace RestaurantesApp.Data
{
    public class RestaurantesContext : DbContext
    {
        public RestaurantesContext(DbContextOptions<RestaurantesContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
        }
    }
}
