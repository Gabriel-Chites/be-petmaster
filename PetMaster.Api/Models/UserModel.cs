using PetMaster.Domain.Entities;
using PetMaster.Domain.Enums;

namespace PetMaster.Api.Models;

public class UserModel
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? CRMV { get; set; }
    public string CPF { get; set; } = string.Empty;
    public string Store { get; set; } = string.Empty;
    public EUserType Type { get; set; }
    public bool FirstAccess { get; set; } = false;

    public static explicit operator User(UserModel user)
     => new(
         user.Name,
         user.Phone,
         user.Email,
         user.CRMV,
         user.CPF,
         user.Store,
         user.Type);
}
