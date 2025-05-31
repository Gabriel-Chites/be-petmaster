namespace PetMaster.Domain.Request;

public class FirstAccessRequest
{
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Password { get; set; } = null!;
}
