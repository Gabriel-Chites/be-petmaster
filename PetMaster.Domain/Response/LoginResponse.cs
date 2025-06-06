namespace PetMaster.Domain.Response
{
    public class LoginResponse
    {
        public bool CanAccess { get; set; }
        public bool? FirstAccess { get; set; }
    }
}