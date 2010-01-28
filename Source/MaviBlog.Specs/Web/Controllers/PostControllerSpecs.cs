using Machine.Specifications;
using MaviBlog.Web.Controllers.Post;

namespace MaviBlog.Specs.Web.Controllers
{
    public class PostControllerSpecs{}

    [Subject(typeof(PostController)), Tags("developer", "display post")]
    public class post_controller_when_handling_request
    {
        private static PostController controller;

        Establish context = () =>
            controller = null;

        Because of = () =>
            controller = new PostController();

        It should_not_be_null = () =>
            controller.ShouldNotBeNull();
    }
}
