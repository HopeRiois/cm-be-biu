using cm_be_biu.Data;
using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Repositories
{
    public class EspecialidadRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Especialidad>> GetEspecialidadesByIdCentroMedico(long idCentroMedico)
        {
            return await _context.Especialidades.Where(p => p.CentroMedico.Id == idCentroMedico).ToListAsync();
        }

        public async Task<Especialidad> AddAsync(Especialidad op)
        {
            _context.Especialidades.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Especialidad?> DeleteAsync(long id)
        {
            var op = await _context.Especialidades.FindAsync(id);
            if (op == null) return null;

            _context.Especialidades.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Especialidad> UpdateAsync(Especialidad op)
        {
            _context.Especialidades.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }
    }
}
