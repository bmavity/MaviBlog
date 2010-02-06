using System.Web.Security;

namespace MaviBlog.Web.Core
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public bool AuthenticateUserNameAndPassword(string userName, string password)
        {
            return userName == password;
        }

        public void AddCookieForUser(string userName)
        {
            FormsAuthentication.SetAuthCookie(userName, false);
        }
    }
}