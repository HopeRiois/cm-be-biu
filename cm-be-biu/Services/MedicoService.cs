using cm_be_biu.Models;
using cm_be_biu.Repositories;
using cm_be_biu.Requests;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Services
{
    public class MedicoService(MedicoRepository medicoRepository, UsuarioService usuarioService, RolService rolService)
    {

        private readonly UsuarioService _usuarioService = usuarioService;

        private readonly RolService _rolService = rolService;       
    
        private readonly MedicoRepository _medicoRepository = medicoRepository;

        public async Task<List<Medico>> GetEspecialidadesByIdEspecialidad(long idEspecialidad)
        {
            return await _medicoRepository.GetEspecialidadesByIdEspecialidad(idEspecialidad);
        }

        public async Task<Medico?> AddAsync(RegisterMedicoRequest request)
        {
            Usuario usuario = request.Adapt<Usuario>();

            Rol? rol = await _rolService.GetRol(1);
            if (rol == null) return null;

            usuario.Rol = rol;

            Usuario? usuarioC = await _usuarioService.CreateUsuario(usuario);
            if (usuarioC == null) return null;

            Medico medico = request.Adapt<Medico>();
            medico.Usuario = usuarioC;

            return await _medicoRepository.AddAsync(medico);
        }
    }
}
