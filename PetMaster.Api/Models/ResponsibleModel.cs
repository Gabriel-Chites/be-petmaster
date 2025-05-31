using PetMaster.Domain.Entities;

namespace PetMaster.Api.Models;

public class ResponsibleModel
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<PetModel> Pets { get; set; } = new();

    public static explicit operator Responsible(ResponsibleModel responsible)
        => new(
            responsible.Name,
            responsible.Phone,
            responsible.Email,
            responsible.Address);
}
