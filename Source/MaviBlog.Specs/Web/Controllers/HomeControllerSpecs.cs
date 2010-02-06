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
    public class when_executing_index_action
    {
        private static HomeController controller;
        private static HomeViewModel viewModel;
        private static IEnumerable<PostViewModel> posts;

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<HomeController>();

            posts = new[] { new PostViewModel { Title = "title 1" }, new PostViewModel { Title = "title 2" }, };

            mocker.Get<IPostRepository>()
                .Stub(x => x.GetLatestPosts())
                .Return(posts);

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("title 1"))
                .Return("encoded title 1");

            mocker.Get<ITitleUrlEncoder>()
                .Stub(x => x.EncodeTitle("title 2"))
                .Return("encoded title 2");

            controller = mocker.ClassUnderTest;
        };

        Because of = () =>
            viewModel = controller.Index();

        It should_include_recent_posts = () =>
            viewModel.Posts.ShouldBeTheSameAs(posts);

        It should_add_encoded_title_to_all_posts = () =>
        {
            viewModel.Posts.ElementAt(0).UrlEncodedTitle.ShouldEqual("encoded title 1");
            viewModel.Posts.ElementAt(1).UrlEncodedTitle.ShouldEqual("encoded title 2");
        };
    }
}
// ReSharper restore InconsistentNaming