using Machine.Specifications;
using MaviBlog.Web.Controllers.Post;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace MaviBlog.Specs.Web.Controllers
{
    public class PostControllerSpecs{}

    [Subject(typeof(PostController)), Tags("developer", "display post")]
    public class when_executing_index_action_with_a_post_title_specified
    {
        private static PostViewModel post;
        private static PostController controller;
        private static PostViewModel viewModel;

        private Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<PostController>();

            post = new PostViewModel();

            mocker.Get<IPostRepository>()
                .Stub(x => x.GetPostByUrlEncodedTitle("test-post_name"))
                .Return(post);

            controller = mocker.ClassUnderTest;
        };

        Because of = () =>
            viewModel = controller.Index(new PostInputModel
            {
                UrlFormattedPostTitle = "test-post_name",
            });

        It should_return_post = () =>
            viewModel.ShouldBeTheSameAs(post);
    }
}
