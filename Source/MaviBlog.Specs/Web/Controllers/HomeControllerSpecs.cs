using System.Collections.Generic;
using Machine.Specifications;
using MaviBlog.Web.Controllers.Home;
using StructureMap.AutoMocking;
using Rhino.Mocks;

namespace MaviBlog.Specs.Web.Controllers
{
    public class HomeControllerSpecs {}

    [Subject(typeof(HomeController))]
    public class home_page_when_showing_default_display
    {
        private static HomeController controller;
        private static HomeViewModel viewModel;
        private static IEnumerable<PostViewModel> posts;

        Establish context = () =>
        {
            var mocker = new RhinoAutoMocker<HomeController>();

            posts = new[] { new PostViewModel(), new PostViewModel() };

            mocker.Get<IPostRepository>()
                .Stub(x => x.GetLatestPosts())
                .Return(posts);

            controller = mocker.ClassUnderTest;
        };

        Because of = () =>
            viewModel = controller.Index();

        It should_display_recent_posts = () =>
        {
            viewModel.Posts.ShouldBeTheSameAs(posts);
        };
    }
}