using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMaster.Domain.Entities;
public abstract class Entity
{
    public Guid Id { get; init; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
