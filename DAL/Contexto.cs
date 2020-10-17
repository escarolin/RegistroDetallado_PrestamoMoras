using Microsoft.EntityFrameworkCore;
using RegistroDetallado_PrestamoMoras.Entidades;

namespace RegistroDetallado_PrestamoMoras.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Moras> Moras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Prestamo.db");
        }
    }
}