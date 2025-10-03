using cm_be_biu.Data;
using cm_be_biu.Models;
using System.Data;

namespace cm_be_biu.Repositories
{
    public class RolRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<Rol?> GetByIdAsync(long id)
        {
            return await _context.Roles.FindAsync(id);
        }
   

        public async Task<Rol> AddAsync(Rol op)
        {
            _context.Roles.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Rol?> DeleteAsync(long id)
        {
            var op = await _context.Roles.FindAsync(id);
            if (op == null) return null;

            _context.Roles.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Rol> UpdateAsync(Rol op)
        {
            _context.Roles.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }
    }
}
