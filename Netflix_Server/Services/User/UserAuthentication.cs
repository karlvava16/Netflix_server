using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Services.PasswordGroup;

namespace Netflix_Server.Services.UserGroup
{
    public class UserAuthentication : IUserAuthentication
    {
        MovieContext _dbContext { get; set; }
        IPasswordHashing _passwordHashing;
        public UserAuthentication(MovieContext database, IPasswordHashing passwordHashing)
        {
            _dbContext = database;
            _passwordHashing = passwordHashing;
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                User user = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == email);

                if (user != null)
                {
                    bool isValidPassword =  _passwordHashing.VerifyPasswordAsync(user.HashedPassword, password, user.PasswordSalt);

                    if (isValidPassword)
                    {
                        return user;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public async Task<User?> RegisterUserAsync(string email, string password, int pricingPlanId)
        {
            try
            {
                User? existingUser = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == email);

                if (existingUser == null)
                {
                    (string hashedPassword, string salt) = _passwordHashing.HashPasswordAsync(password);


                    User newUser = new User
                    {
                        Email = email,
                        Name = email,
                        HashedPassword = hashedPassword,
                        PasswordSalt = salt,
                        RegistrationDate = DateTime.Now,
                        PricingPlanId = pricingPlanId,
                        WatchedMovies = new List<Movie>(),
                    };

                    _dbContext.Users.Add(newUser);
                    _dbContext.SaveChanges();

                    return newUser;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
