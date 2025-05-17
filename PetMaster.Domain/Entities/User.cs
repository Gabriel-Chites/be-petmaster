using PetMaster.Domain.Enums;

namespace PetMaster.Domain.Entities;
public class User : Entity
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? CRMV { get; set; }
    public string CPF { get; set; } = null!;
    public string Store { get; set; } = null!;
    public string RegistrationNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public EUserType Type { get; set; }

}
