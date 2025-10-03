using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cm_be_biu.Models
{
    public class CentroMedico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required string Nombre { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Estado { get; set; }
    }
}
