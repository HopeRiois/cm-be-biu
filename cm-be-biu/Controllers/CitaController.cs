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
    public class CitaController(AppDbContext context, CitaService citaService) : BaseController<Cita>(context)
    {
        private readonly CitaService _citaService = citaService;


        [Authorize]
        [HttpPost]
        [Route("solicitar-cita")]
        public async Task<IActionResult> CreateCita(Cita cita)
        {
            Cita citas = await _citaService.CreateCita(cita);
            if (citas == null) return BadRequest();
            return Ok(citas);
        }

        [Authorize]
        [HttpGet]
        [Route("obtener-citas-paciente")]
        public async Task<IActionResult> GetCitasByIdPaciente(long idPaciente)
        {
            List<Cita> citas = await _citaService.GetCitasByIdPaciente(idPaciente);
            if (citas.IsNullOrEmpty()) return NotFound();
            return Ok(citas);
        }

        [Authorize(Roles = "admin,funcionario")]
        [HttpGet]
        [Route("obtener-citas-medico")]
        public async Task<IActionResult> GetCitasByIdMedico(long idMedico)
        {
            List<Cita> citas = await _citaService.GetCitasByIdMedico(idMedico);
            if (citas.IsNullOrEmpty()) return NotFound();
            return Ok(citas);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("obtener-citas-especialidad")]
        public async Task<IActionResult> GetCitasByIdEspecialidad(long idEspecialidad)
        {
            List<Cita> citas = await _citaService.GetCitasByIdEspecialidad(idEspecialidad);
            if (citas.IsNullOrEmpty()) return NotFound();
            return Ok(citas);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("obtener-citas-centro-medico")]
        public async Task<IActionResult> GetCitasByIdCentroMedico(long idCentroMedico)
        {
            List<Cita> citas = await _citaService.GetCitasByIdCentroMedico(idCentroMedico);
            if (citas.IsNullOrEmpty()) return NotFound();
            return Ok(citas);
        }
    }

}
