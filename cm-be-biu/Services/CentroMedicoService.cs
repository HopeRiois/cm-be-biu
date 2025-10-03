using cm_be_biu.Models;
using cm_be_biu.Repositories;

namespace cm_be_biu.Services
{
    public class CentroMedicoService(CentroMedicoRepository cmRepository)
    {
        private readonly CentroMedicoRepository _cmRepository = cmRepository;

        public async Task<List<CentroMedico>> GetAllCentroMedico()
        {
            return await _cmRepository.GetAllAsync();
        }
    }
}
