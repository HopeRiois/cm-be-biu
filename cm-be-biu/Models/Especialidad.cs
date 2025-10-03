using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cm_be_biu.Models
{
    public class Especialidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; }
        public virtual required CentroMedico CentroMedico { get; set; }
    }
}
