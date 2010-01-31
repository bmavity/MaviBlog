using Machine.Specifications;
using Machine.Specifications.Model;
using MaviBlog.Web.Controllers.Post;
using StructureMap;

namespace MaviBlog.Specs.Integration
{
    public class PostCreationSpecs {}

    [Subject("Post creation")]
    public class when_displaying_a_recently_created_post : full_app_setup
    {
        private static PostViewModel post;

        Because of = () =>
            post = controller.Get(new PostIndexInputModel
            {
                UrlFormattedPostTitle = "hi-2-u",
            });

        It should_have_the_post_title = () =>
            post.Title.ShouldEqual("Hi 2 u");
    }

    public class full_app_setup
    {
        protected static PostController controller;

        Establish context = () =>
        {
            var container = new Container(init =>
            {
                init.AddRegistry<CoreStructureMapRegistry>();
            });
            controller = container.GetInstance<PostController>();

            controller.Post(new PostCreateInputModel
            {
                Title = "Hi 2 u",
            });
        };

        Cleanup after = () =>
            InMemoryPostRepository.Reset();
    }
}
