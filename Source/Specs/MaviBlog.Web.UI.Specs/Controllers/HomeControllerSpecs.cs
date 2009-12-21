using Machine.Specifications;
using MaviBlog.Web.UI.Controllers;

namespace MaviBlog.Web.UI.Specs
{
    public class HomeControllerSpecs {}

    [Subject(typeof(HomeController))]
    public class home_controller_when_handling_request
    {
        private static HomeController controller;

        Establish context = () =>
        {

        };

        Because of = () =>
            controller = new HomeController();

        It should_properly_handle_the_request;
    }
}