using WebJerseyGoal.DataBase.Entitties.Identity;

namespace WebJerseyGoal.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(UserEntity user);
    }
}
