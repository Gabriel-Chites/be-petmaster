using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Entities;
public class Service : Entity
{
    public Service(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
