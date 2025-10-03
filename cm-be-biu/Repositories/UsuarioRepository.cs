using cm_be_biu.Data;
using cm_be_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Repositories
{
    public class UsuarioRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Obtener usuario para inicio de sesión
        /// </summary>
        /// <returns>Usuario</returns>
        public async Task<Usuario> UpdatePassword(String documento, String password)
        {
            Usuario user = await _context.Usuarios.Where(user => user.Documento == documento).FirstAsync();
            user.Contraseña = password;
            return await UpdateAsync(user);
        }


        /// <summary>
        /// Obtener usuario para inicio de sesión
        /// </summary>
        /// <returns>Usuario</returns>
        public async Task<Usuario> Login(String identifier, String password)
        {
            return await _context.Usuarios.Where(user => (user.Documento == identifier || user.Correo == identifier) && user.Contraseña == password).FirstAsync();
        }

        /// <summary>
        /// Validar si existe el nombre de usuario o correo estan ocupados
        /// </summary>
        /// <returns>Usuario</returns>
        public async Task<Boolean> CheckIfUsuarioOrEmailExists(String userName, String email)
        {
            var result = await _context.Usuarios.Where(user => user.Documento == userName || user.Correo == email).FirstOrDefaultAsync();
            return result != null;
        }

        /// <summary>
        /// Validar si el correo esta ocupado
        /// </summary>
        /// <returns>Usuario</returns>
        public async Task<Boolean> CheckIfEmailExists(String email)
        {
            var result = await _context.Usuarios.Where(user => user.Correo == email).FirstOrDefaultAsync();
            return result != null;
        }


        /// <summary>
        /// Obtener todos los Usuarios
        /// </summary>
        /// <returns>Usuario List</returns>
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        /// <summary>
        /// Obtener un Usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario</returns>
        public async Task<Usuario?> GetByIdAsync(long id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        /// <summary>
        /// Agregar un Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns>Usuario added</returns>
        public async Task<Usuario> AddAsync(Usuario Usuario)
        {
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

        /// <summary>
        /// Actualizar un Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns>Usuario updated</returns>
        public async Task<Usuario> UpdateAsync(Usuario Usuario)
        {
            _context.Usuarios.Update(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

        /// <summary>
        /// Eliminar un Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario deleted</returns>
        public async Task<Usuario?> DeleteAsync(int id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null) return null;

            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

    }
}
