using cm_be_biu.Data;
using cm_be_biu.Models;
using cm_be_biu.Requests;
using cm_be_biu.Services;
using cm_be_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController(AppDbContext context, PacienteService pacienteService) : BaseController<Paciente>(context)
    {
        private readonly PacienteService _pacienteService = pacienteService;

        [AllowAnonymous]
        [HttpGet]
        [Route("registrar-paciente")]
        public async Task<IActionResult> PacienteRegister(RegisterPacienteRequest request)
        {
            Paciente? paciente = await _pacienteService.AddAsync(request);
            if (paciente == null) return BadRequest();
            return Ok(paciente);
        } 

    }
}
