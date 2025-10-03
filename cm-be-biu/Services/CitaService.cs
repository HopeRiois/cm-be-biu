using cm_be_biu.Models;
using cm_be_biu.Repositories;
using Microsoft.EntityFrameworkCore;

namespace cm_be_biu.Services
{
    public class CitaService(CitaRepository citaRepository)
    {
        private readonly CitaRepository _citaRepository = citaRepository;

        public async Task<List<Cita>> GetCitasByIdPaciente(long idPaciente)
        {
            return await _citaRepository.GetCitasByIdPaciente(idPaciente);
        }

        public async Task<List<Cita>> GetCitasByIdMedico(long idMedico)
        {
            return await _citaRepository.GetCitasByIdMedico(idMedico);
        }

        public async Task<List<Cita>> GetCitasByIdEspecialidad(long idEspecialidad)
        {
            return await _citaRepository.GetCitasByIdEspecialidad(idEspecialidad);
        }

        public async Task<List<Cita>> GetCitasByIdCentroMedico(long idCentroMedico)
        {
            return await _citaRepository.GetCitasByIdCentroMedico(idCentroMedico);
        }

        public async Task<Cita> CreateCita(Cita cita)
        {
            return await _citaRepository.AddAsync(cita);
        }
    }
}
