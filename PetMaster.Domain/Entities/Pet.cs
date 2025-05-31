using PetMaster.Domain.Enums;

namespace PetMaster.Domain.Entities;
public class Pet : Entity
{
    public Pet(
        string name,
        string specie,
        string breed,
        int age,
        double weigth,
        EPort porte)
    {
        Name = name;
        Specie = specie;
        Breed = breed;
        Age = age;
        Weigth = weigth;
        Porte = porte;
    }

    public string Name { get; set; } = null!;
    public string Specie { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public int Age { get; set; }
    public double Weigth { get; set; }
    public EPort Porte { get; set; }
}
