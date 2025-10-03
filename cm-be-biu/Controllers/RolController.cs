using cm_be_biu.Data;
using cm_be_biu.Models;
using cm_be_biu.Services;
using cm_be_biu.Utils;
using Microsoft.AspNetCore.Mvc;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController(AppDbContext context, RolService rolService) : BaseController<Rol>(context)
    {
        private readonly RolService _rolService = rolService;
    }
}
