using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cm_be_biu.Models
{
    public class Medico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string TipoDeDocumento { get; set; }
        public required string Documento { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Sexo { get; set; }
        public required string Celular { get; set; }
        public required string Correo { get; set; }
        public required string Estado { get; set; }
        public virtual required Usuario Usuario { get; set; }
        public virtual required Especialidad Especialidad { get; set; }
    }
}
