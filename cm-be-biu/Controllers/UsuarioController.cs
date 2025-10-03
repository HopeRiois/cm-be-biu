using cm_be_biu.Data;
using cm_be_biu.Models;
using cm_be_biu.Services;
using cm_be_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cm_be_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(AppDbContext context, Encryption encryption, UsuarioService usuarioService) : BaseController<Usuario>(context)
    {
        private readonly Encryption _encryption = encryption;

        private readonly UsuarioService _usuarioService = usuarioService;

        [AllowAnonymous]
        [HttpGet]
        [Route("encrypt")]
        public IActionResult EncryptPassword(string password) => Ok(_encryption.EncryptAES256(password));

        [AllowAnonymous]
        [HttpGet]
        [Route("decrypt")]
        public IActionResult DecryptPassword(string password) => Ok(_encryption.DecryptAES256(password));

        [AllowAnonymous]
        [HttpGet]
        [Route("validar-correo")]
        public async Task<IActionResult> CheckIfEmailExists(String email) => Ok(await _usuarioService.CheckIfEmailExists(email));

        [AllowAnonymous]
        [HttpGet]
        [Route("validar-documento")]
        public async Task<IActionResult> CheckIfUserOrEmailExists(String documento, String email) => Ok(await _usuarioService.CheckIfUsuarioOrEmailExists(documento, email));


        [AllowAnonymous]
        [HttpGet]
        [Route("cambiar-clave")]
        public async Task<IActionResult> ResetPassword(String email, String password) => Ok(await _usuarioService.UpdatePassword(email, _encryption.EncryptAES256(password)));
    }
}
