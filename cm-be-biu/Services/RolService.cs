using cm_be_biu.Models;
using cm_be_biu.Repositories;

namespace cm_be_biu.Services
{
    public class RolService(RolRepository roleRepository)
    {
        private readonly RolRepository _roleRepository = roleRepository;

        public async Task<Rol?> GetRol(long id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

    }
}
