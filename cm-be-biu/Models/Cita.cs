using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cm_be_biu.Models
{
    public class Cita
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required DateTime FechaCita { get; set; }
        public required string Estado { get; set; }
        public virtual required Paciente Paciente { get; set; }
        public virtual required Medico Medico { get; set; }
        public virtual required Especialidad Especialidad { get; set; }
        public virtual required CentroMedico CentroMedico { get; set; }
    }
}
