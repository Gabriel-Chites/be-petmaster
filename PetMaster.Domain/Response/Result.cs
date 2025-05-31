using PetMaster.Domain.Entities;

namespace PetMaster.Domain.Response;
public class Result
{
    public Result(
        bool success,
        string? message,
        object? entity = null)
    {
        Success = success;
        Message = message;
        Data = entity;
    }

    public Result(
       bool success,
       object? entity = null)
    {
        Success = success;
        Data = entity;
    }

    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; } = null!;
}
