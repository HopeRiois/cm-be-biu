namespace cm_be_biu.Responses
{
    public class AuthResponse
    {
        public long IdUser { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Jwt { get; set; }
        public int ExpirationTime { get; set; }
    }
}
