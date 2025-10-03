using cm_be_biu.Data;
using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Repositories
{
    public class CentroMedicoRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CentroMedico>> GetAllAsync()
        {
            return await _context.CentroMedicos.ToListAsync();
        }

        public async Task<CentroMedico> AddAsync(CentroMedico op)
        {
            _context.CentroMedicos.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<CentroMedico?> DeleteAsync(long id)
        {
            var op = await _context.CentroMedicos.FindAsync(id);
            if (op == null) return null;

            _context.CentroMedicos.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<CentroMedico> UpdateAsync(CentroMedico op)
        {
            _context.CentroMedicos.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }

    }
}
