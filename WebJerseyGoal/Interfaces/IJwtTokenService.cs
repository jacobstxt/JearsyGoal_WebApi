namespace WebJerseyGoal.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync();
    }
}
