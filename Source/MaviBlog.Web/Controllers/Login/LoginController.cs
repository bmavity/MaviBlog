namespace MaviBlog.Web.Controllers.Login
{
    public class LoginController
    {
        private readonly IAuthenticationService _authService;

        public LoginController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public void Post(LoginInputModel loginInfo)
        {
            if(_authService.AuthenticateUserNameAndPassword(loginInfo.UserName, loginInfo.Password))
            {
                _authService.AddCookieForUser(loginInfo.UserName);
            }
        }
    }
}