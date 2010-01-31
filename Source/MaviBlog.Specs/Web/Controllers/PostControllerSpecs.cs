using Machine.Specifications;
using MaviBlog.Web.Controllers.Post;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace MaviBlog.Specs.Web.Controllers
{
    public class PostControllerSpecs{}

    [Subject(typeof(PostController)), Tags("developer", "display post")]
    public class when_executing_get_action_with_a_post_title_specified
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
            viewModel = controller.Get(new PostIndexInputModel
            {
                UrlFormattedPostTitle = "test-post_name",
            });

        It should_return_post = () =>
            viewModel.ShouldBeTheSameAs(post);
    }

    [Subject(typeof(PostController)), Tags("developer", "create post")]
    public class when_executing_post_action
    {
        private static PostController controller;
        private static PostCreateResult result;
        private static Post createdPost;

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<PostController>();

            mocker.Get<IPostRepository>()
                .Stub(x => x.Save(null))
                .IgnoreArguments()
                .Return(1);

            controller = mocker.ClassUnderTest;
        };

        Because of = () =>
            result = controller.Post(new PostCreateInputModel
            {
                Content = "<p>Hello World</p>",
            });

        It should_return_the_new_post_id = () =>
            result.Id.ShouldEqual(1);
    }
}
