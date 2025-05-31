using PetMaster.Domain.Entities;

namespace PetMaster.Api.Models;

public class ServiceModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static explicit operator Service(ServiceModel service)
        => new(
            service.Title,
            service.Description);
}
