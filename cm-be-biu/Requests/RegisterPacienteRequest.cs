namespace cm_be_biu.Requests
{
    public class RegisterPacienteRequest
    {
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string TipoDeDocumento { get; set; }
        public required string Documento { get; set; }
        public required string Celular { get; set; }
        public required string Correo { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Sexo { get; set; }
        public required string Direccion { get; set; }
        public required string Contraseña { get; set; }
    }
}
