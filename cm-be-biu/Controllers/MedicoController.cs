using cm_be_biu.Data;
using cm_be_biu.Models;
using cm_be_biu.Requests;
using cm_be_biu.Services;
using cm_be_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController(AppDbContext context, MedicoService medicoService) : BaseController<Medico>(context)
    {
        private readonly MedicoService _medicoService = medicoService;

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("registrar-medico")]
        public async Task<IActionResult> MedicoRegister(RegisterMedicoRequest request)
        {
            Medico? medico = await _medicoService.AddAsync(request);
            if (medico == null) return BadRequest();
            return Ok(medico);
        }

        [Authorize]
        [HttpGet]
        [Route("obtener-medicos-especialidad")]
        public async Task<IActionResult> GetMedicosByEspecilidad(long idEspecialidad)
        {
            List<Medico> medicos = await _medicoService.GetEspecialidadesByIdEspecialidad(idEspecialidad);
            if (medicos.IsNullOrEmpty()) return NotFound();
            return Ok(medicos);
        }
    }
}
