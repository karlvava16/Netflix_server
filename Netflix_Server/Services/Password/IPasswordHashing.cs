namespace Netflix_Server.Services.PasswordGroup
{
    public interface IPasswordHashing
    {
        (string hashedPassword, string salt) HashPasswordAsync(string userPassword);
        bool VerifyPasswordAsync(string hashedPassword, string userPassword, string salt);
    }
}
