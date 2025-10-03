using cm_be_biu.Data;
using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Repositories
{
    public class MedicoRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Medico>> GetEspecialidadesByIdEspecialidad(long idEspecialidad)
        {
            return await _context.Medicos.Where(p => p.Especialidad.Id == idEspecialidad).ToListAsync();
        }

        public async Task<Medico> AddAsync(Medico op)
        {
            _context.Medicos.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Medico?> DeleteAsync(long id)
        {
            var op = await _context.Medicos.FindAsync(id);
            if (op == null) return null;

            _context.Medicos.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Medico> UpdateAsync(Medico op)
        {
            _context.Medicos.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }
    }
}
