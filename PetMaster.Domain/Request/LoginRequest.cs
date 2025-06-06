namespace PetMaster.Domain.Request
{
    public class LoginRequest
    {
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
    }
}