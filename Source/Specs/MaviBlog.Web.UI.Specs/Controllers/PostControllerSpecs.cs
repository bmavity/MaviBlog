using Machine.Specifications;
using MaviBlog.Web.UI.Controllers.Post;

namespace MaviBlog.Web.UI.Specs
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
