namespace MaviBlog.Web.Controllers.Login
{
    public interface IAuthenticationService
    {
        bool AuthenticateUserNameAndPassword(string userName, string password);
        void AddCookieForUser(string userName);
    }
}