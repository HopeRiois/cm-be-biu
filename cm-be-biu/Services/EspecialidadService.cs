using cm_be_biu.Models;
using cm_be_biu.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Services
{
    public class EspecialidadService(EspecialidadRepository especialidadRepository)
    {
        private readonly EspecialidadRepository _especialidadRepository = especialidadRepository;

        public async Task<List<Especialidad>> GetEspecialidadesByIdCentroMedico(long idCentroMedico)
        {
            return await _especialidadRepository.GetEspecialidadesByIdCentroMedico(idCentroMedico);
        }

    }
}
