using Machine.Specifications;
using MaviBlog.Web.Controllers.Post;
using StructureMap;

namespace MaviBlog.Specs.Integration
{
    public class PostCreationSpecs {}

    [Subject("Post creation")]
    public class when_displaying_a_created_post : full_app_setup
    {
        private static PostViewModel post;

        Because of = () =>
            post = controller.Get(new PostIndexInputModel
            {
                UrlFormattedPostTitle = "fires-of-heaven",
            });

        It should_have_the_title = () =>
            post.Title.ShouldEqual("Fires of Heaven");

        It should_have_the_author = () =>
            post.Author.ShouldEqual("Robert Jordan");
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
                Author = "Robert Jordan",
                Title = "Fires of Heaven",
            });
        };

        Cleanup after = () =>
            InMemoryPostRepository.Reset();
    }
}
