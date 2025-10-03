using cm_be_biu.Data;
using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Repositories
{
    public class CitaRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Cita>> GetCitasByIdPaciente(long idPaciente)
        {
            return await _context.Citas.Where(p => p.Paciente.Id == idPaciente).ToListAsync();
        }

        public async Task<List<Cita>> GetCitasByIdMedico(long idMedico)
        {
            return await _context.Citas.Where(p => p.Medico.Id == idMedico).ToListAsync();
        }

        public async Task<List<Cita>> GetCitasByIdEspecialidad(long idEspecialidad)
        {
            return await _context.Citas.Where(p => p.Especialidad.Id == idEspecialidad).ToListAsync();
        }

        public async Task<List<Cita>> GetCitasByIdCentroMedico(long idCentroMedico)
        {
            return await _context.Citas.Where(p => p.CentroMedico.Id == idCentroMedico).ToListAsync();
        }

        public async Task<Cita> AddAsync(Cita op)
        {
            _context.Citas.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Cita?> DeleteAsync(long id)
        {
            var op = await _context.Citas.FindAsync(id);
            if (op == null) return null;

            _context.Citas.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Cita> UpdateAsync(Cita op)
        {
            _context.Citas.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }

    }
}
