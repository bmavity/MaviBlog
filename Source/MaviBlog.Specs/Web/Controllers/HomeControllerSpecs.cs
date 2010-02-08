using System.Collections.Generic;
using Machine.Specifications;
using MaviBlog.Web.Controllers.Home;
using StructureMap.AutoMocking;
using Rhino.Mocks;
using System.Linq;

// ReSharper disable InconsistentNaming
namespace MaviBlog.Specs.Web.Controllers
{
    public class HomeControllerSpecs {}

    [Subject(typeof(HomeController))]
    public class when_executing_index_action : home_controller_context
    {
        private static HomeViewModel viewModel;

        Because of = () =>
            viewModel = controller.Index();

        It should_include_recent_posts = () =>
            viewModel.Posts.ShouldBeTheSameAs(posts);

        It should_add_encoded_title_to_all_posts = () =>
        {
            viewModel.Posts.ElementAt(0).UrlEncodedTitle.ShouldEqual("encoded title");
            viewModel.Posts.ElementAt(1).UrlEncodedTitle.ShouldEqual("encoded title");
            viewModel.Posts.ElementAt(2).UrlEncodedTitle.ShouldEqual("encoded title");
        };
    }

    public class home_controller_context
    {
        protected static HomeController controller;
        protected static IEnumerable<PostViewModel> posts;
        protected static PostViewModel firstPublishedPost;
        protected static PostViewModel secondPublishedPost;
        protected static PostViewModel thirdPublishedPost;

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<HomeController>();

            firstPublishedPost = new PostViewModel
            {
                PublishDate = "4/6/2008",
                Title = "title 3",
            };

            secondPublishedPost = new PostViewModel
            {
                PublishDate = "1/5/2009",
                Title = "title 2",
            };

            thirdPublishedPost = new PostViewModel
            {
                PublishDate = "2/1/2010",
                Title = "title 1",
            };

            posts = new[] { firstPublishedPost, thirdPublishedPost, secondPublishedPost };

            mocker.Get<IPostRepository>()
                .Stub(x => x.GetLatestPosts())
                .Return(posts);

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("title 1"))
                .Return("encoded title");

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("title 2"))
                .Return("encoded title");

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("title 3"))
                .Return("encoded title");

            controller = mocker.ClassUnderTest;
        };
    }
}
// ReSharper restore InconsistentNaming