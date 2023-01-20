using Microsoft.EntityFrameworkCore;
using WSClinica.Models;
namespace WSClinica.Data
{
    public class DbClinicaContext:DbContext
    {
        public DbClinicaContext(DbContextOptions<DbClinicaContext> options):base(options) { }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
    }
}
