using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<CentroMedico> CentroMedicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
