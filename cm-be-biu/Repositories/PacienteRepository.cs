using cm_be_biu.Data;
using cm_be_biu.Models;

namespace cm_be_biu.Repositories
{
    public class PacienteRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;


        public async Task<Paciente> AddAsync(Paciente op)
        {
            _context.Pacientes.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Paciente?> DeleteAsync(long id)
        {
            var op = await _context.Pacientes.FindAsync(id);
            if (op == null) return null;

            _context.Pacientes.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<Paciente> UpdateAsync(Paciente op)
        {
            _context.Pacientes.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }
    }
}
