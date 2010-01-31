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

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<PostController>();

            post = new PostViewModel();

            var postId = 3;

            mocker.Get<IUrlEncodedTitleRepository>()
                .Stub(x => x.GetPostIdForUrlEncodedTitle("test-post_name"))
                .Return(postId);

            mocker.Get<IPostRepository>()
                .Stub(x => x.GetPostById(postId))
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
        private static RhinoAutoMocker<PostController> mocker;

        Establish context = () =>
        {
            mocker = new RhinoAutoMocker<PostController>();

            mocker.Get<IPostRepository>()
                .Stub(x => x.Save(null))
                .IgnoreArguments()
                .Return(1);

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("hi 2 u"))
                .Return("hi-2-u");

            controller = mocker.ClassUnderTest;
        };

        Because of = () =>
            result = controller.Post(new PostCreateInputModel
            {
                Title = "hi 2 u",
            });

        It should_return_the_new_post_id = () =>
            result.Id.ShouldEqual(1);

        It should_map_the_new_post_id_to_the_url_endcoded_title = () =>
            mocker.Get<IUrlEncodedTitleRepository>()
                .AssertWasCalled(x => x.SaveUrlToPostIdMap("hi-2-u", 1));
    }
}
