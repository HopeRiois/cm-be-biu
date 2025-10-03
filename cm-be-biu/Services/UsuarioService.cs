using cm_be_biu.Models;
using cm_be_biu.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Services
{
    public class UsuarioService(UsuarioRepository UsuarioRepository, RolService roleService)
    {
        private readonly UsuarioRepository _UsuarioRepository = UsuarioRepository;

        private readonly RolService _roleService = roleService;

        public async Task<Boolean> CheckIfEmailExists(String email)
        {
            return await _UsuarioRepository.CheckIfEmailExists(email);
        }

        public async Task<Boolean> CheckIfUsuarioOrEmailExists(String documento, String email)
        {
            return await _UsuarioRepository.CheckIfUsuarioOrEmailExists(documento, email);
        }

        public async Task<Usuario?> CreateUsuario(Usuario user)
        {
            if (await _UsuarioRepository.CheckIfUsuarioOrEmailExists(user.Documento, user.Correo))
                return null;

            var rol = await _roleService.GetRol(user.Rol.Id);
            if (rol != null)
                user.Rol = rol;

            return await _UsuarioRepository.AddAsync(user);

        }

        public async Task<Usuario> UpdatePassword(String email, String password)
        {
            return await _UsuarioRepository.UpdatePassword(email, password);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _UsuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetById(long id)
        {
            return await _UsuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> Create(Usuario Usuario)
        {
            return await _UsuarioRepository.AddAsync(Usuario);
        }

        public async Task<Usuario> Update(Usuario Usuario)
        {
            return await _UsuarioRepository.UpdateAsync(Usuario);
        }

        public async Task<Usuario?> Delete(int id)
        {
            return await _UsuarioRepository.DeleteAsync(id);
        }
    }
}
