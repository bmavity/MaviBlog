using Machine.Specifications;
using MaviBlog.Web.Controllers.Login;
using MaviBlog.Web.Core;
using StructureMap.AutoMocking;
using Rhino.Mocks;

// ReSharper disable InconsistentNaming
namespace MaviBlog.Specs.Web.Controllers
{
    public class LoginControllerSpecs {}

    [Subject(typeof(LoginController))]
    public class when_executing_post_action_with_a_valid_user_name_and_password : login_controller
    {
        Establish context = () =>
        {
            authService
                .Stub(x => x.AuthenticateUserNameAndPassword("brian", "password"))
                .Return(true);
        };

        Because of = () =>
            controller.Post(new LoginInputModel
            {
                Password = "password",
                UserName = "brian",
            });

        It should_attach_cookie_for_user = () =>
            authService.AssertWasCalled(x => x.AddCookieForUser("brian"));
    }

    [Subject(typeof(LoginController))]
    public class when_executing_post_action_with_an_invalid_user_name_and_password : login_controller
    {
        Establish context = () =>
        {
            authService
                .Stub(x => x.AuthenticateUserNameAndPassword("brian", "password"))
                .Return(false);
        };

        Because of = () =>
            controller.Post(new LoginInputModel
            {
                Password = "password",
                UserName = "brian",
            });

        It should_not_attach_cookie_for_user = () =>
            authService.AssertWasNotCalled(x => x.AddCookieForUser("brian"));
    }

    public class login_controller
    {
        protected static LoginController controller;
        protected static IAuthenticationService authService;

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<LoginController>();

            authService = mocker.Get<IAuthenticationService>();

            controller = mocker.ClassUnderTest;
        };
    }
}
// ReSharper restore InconsistentNaming