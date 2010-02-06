namespace MaviBlog.Web.Core
{
    public interface IAuthenticationService
    {
        bool AuthenticateUserNameAndPassword(string userName, string password);
        void AddCookieForUser(string userName);
    }
}