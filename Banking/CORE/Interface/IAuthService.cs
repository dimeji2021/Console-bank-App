namespace Banking.CORE.Services
{
    public interface IAuthService
    {
        bool Login(string userName, string password);
        bool Logout();
    }
}