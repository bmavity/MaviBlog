using Machine.Specifications;
using MaviBlog.Web.Controllers.Post;
using StructureMap;

// ReSharper disable InconsistentNaming
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
                UrlEncodedPostTitle = "fires-of-heaven",
            });

        It should_display_the_post = () =>
            post.Title.ShouldEqual("Fires of Heaven");

        It should_have_the_author = () =>
            post.Author.ShouldEqual("Robert Jordan");

        It should_have_the_content = () =>
            post.Content.ShouldEqual("<p>The Wheel of Time turns...</p>");

        It should_have_the_publish_date = () =>
            post.PublishDate.ShouldEqual("1/1/2010");

        It should_have_the_url_encoded_title = () =>
            post.UrlEncodedTitle.ShouldEqual("fires-of-heaven");
    }

    public class full_app_setup
    {
        protected static PostController controller;

        Establish context = () =>
        {
            var container = new Container(init =>
            {
                init.Scan(scan =>
                {
                    scan.AssemblyContainingType<CoreStructureMapRegistry>();
                    scan.WithDefaultConventions();
                });

                init.For<IPostRepository>().Use<InMemoryPostRepository>();
                init.For<IUrlEncodedTitleRepository>().Use<InMemoryUrlEncodedTitleRepository>();
            });
            controller = container.GetInstance<PostController>();

            controller.Post(new PostCreateInputModel
            {
                Author = "Robert Jordan",
                Content = "<p>The Wheel of Time turns...</p>",
                PublishDate = "1/1/2010",
                Title = "Fires of Heaven",
            });
        };

        Cleanup after = () =>
            InMemoryPostRepository.Reset();
    }
}
// ReSharper restore InconsistentNaming