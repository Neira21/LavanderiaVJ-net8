using Microsoft.EntityFrameworkCore;
using LavanderiaVJWeb.Models;

namespace LavanderiaVJWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }    
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<ServiciosDisponibles> ServiciosDisponibles { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Estado> Estados { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Class>()
        //        .Property(c => c.Id)
        //        .HasDefaultValueSql("NEWID()");
        //}
    }
}
