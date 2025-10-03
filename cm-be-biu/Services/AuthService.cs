using cm_be_biu.Models;
using cm_be_biu.Repositories;
using cm_be_biu.Requests;
using cm_be_biu.Responses;
using cm_be_biu.Utils;

namespace cm_be_biu.Services
{
    public class AuthService(UsuarioRepository userRepository, JwtUtils tokenProvider, Encryption encryption)
    {
        private readonly Encryption _encryption = encryption;

        private readonly UsuarioRepository _userRepository = userRepository;

        public async Task<AuthResponse?> HandleLogin(AuthRequest request)
        {
            try
            {
                Usuario user = await _userRepository.Login(request.UserName, _encryption.EncryptAES256(request.Password));
                if (user == null) return null;

                AuthResponse response = tokenProvider.Generate(user);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
