using cm_be_biu.Data;
using cm_be_biu.Models;
using cm_be_biu.Services;
using cm_be_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadController(AppDbContext context, EspecialidadService especialidadService) : BaseController<Especialidad>(context)
    {
        private readonly EspecialidadService _especialidadService = especialidadService;

        [Authorize]
        [HttpGet]
        [Route("obtener-especialidades-centro-medico")]
        public async Task<IActionResult> GetEspecialidadesByIdCentroMedico(long idPaciente)
        {
            List<Especialidad> especialidades = await _especialidadService.GetEspecialidadesByIdCentroMedico(idPaciente);
            if (especialidades.IsNullOrEmpty()) return NotFound();
            return Ok(especialidades);
        }
    }
}
