using PetMaster.Domain.Enums;

namespace PetMaster.Domain.Entities;
public class User : Entity
{
    public User(
        string name,
        string phone,
        string email,
        string? cRMV,
        string cPF,
        string store,
        EUserType type) 
    {
        Name = name;
        Phone = phone;
        Email = email;
        CRMV = cRMV;
        CPF = cPF;
        Store = store;
        Type = type;
    }

    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? CRMV { get; set; }
    public string CPF { get; set; } = null!;
    public string Store { get; set; } = null!;
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Password { get; set; } = null!;
    public EUserType Type { get; set; }
    public bool FirstAccess { get; set; } = true;

    public void SetPassword(string password) => Password = password;
}
