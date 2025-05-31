using PetMaster.Domain.Entities;
using PetMaster.Domain.Enums;

namespace PetMaster.Api.Models;

public class PetModel
{
    public string Name { get; set; } = string.Empty;
    public string Specie { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public double Weigth { get; set; }
    public EPort Porte { get; set; }

    public static explicit operator Pet(PetModel pet)
        => new(
            pet.Name,
            pet.Specie,
            pet.Breed,
            pet.Age,
            pet.Weigth,
            pet.Porte);
}
