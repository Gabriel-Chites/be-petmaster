using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Entities;
public class Responsible : Entity
{
    public Responsible(
        string name,
        string phone,
        string email,
        string address)
    {
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }

    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public List<Pet> Pets { get; set; } = [];
}
