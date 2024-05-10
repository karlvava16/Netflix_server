using Netflix_Server.Models.UserGroup;

namespace Netflix_Server.Services.UserGroup
{
    public interface IUserAuthentication
    {
        Task<User?> AuthenticateUserAsync(string email, string password);
        Task<User?> RegisterUserAsync(string email, string password, int pricingPlanId);
    }
}
