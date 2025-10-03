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
    public class CentroMedicoController(AppDbContext context, CentroMedicoService centroMedicoService) : BaseController<CentroMedico>(context)
    {
        private readonly CentroMedicoService _centroMedicoService = centroMedicoService;

        [Authorize]
        [HttpGet]
        [Route("obtener-centros-medicos")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<CentroMedico> cm = await _centroMedicoService.GetAllCentroMedico();
            if (cm.IsNullOrEmpty()) return NotFound();
            return Ok(cm);
        }

    }
}
