using cm_be_biu.Models;
using cm_be_biu.Repositories;
using cm_be_biu.Requests;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Services
{
    public class PacienteService(PacienteRepository pacienteRepository, UsuarioService usuarioService, RolService rolService)
    {
        private readonly PacienteRepository _pacienteRepository = pacienteRepository;

        private readonly UsuarioService _usuarioService = usuarioService;

        private readonly RolService _rolService = rolService;

        public async Task<Paciente?> AddAsync(RegisterPacienteRequest request)
        {
            Usuario usuario = request.Adapt<Usuario>();

            Rol? rol = await _rolService.GetRol(2);
            if (rol == null) return null;

            usuario.Rol = rol;

            Usuario? usuarioC = await _usuarioService.CreateUsuario(usuario);
            if (usuarioC == null) return null;

            Paciente paciente = request.Adapt<Paciente>();
            paciente.Usuario = usuarioC;

            return await _pacienteRepository.AddAsync(paciente);
        }
    }
}
