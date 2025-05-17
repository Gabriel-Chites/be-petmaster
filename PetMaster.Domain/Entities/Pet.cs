using PetMaster.Domain.Enums;

namespace PetMaster.Domain.Entities;
public class Pet : Entity
{
    public string Name { get; set; } = null!;
    public string Specie { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public int Age { get; set; }
    public double Weigth { get; set; }
    public EPort Porte { get; set; }
}
