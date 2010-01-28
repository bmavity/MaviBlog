using System.Collections.Generic;
using AutoMapper;
using Machine.Specifications;
using MaviBlog.Web.Controllers.Home;
using Rhino.Mocks;

namespace MaviBlog.Specs.Web.Controllers
{
    public class HomeControllerSpecs {}

    [Subject(typeof(HomeController))]
    public class home_controller_when_handling_request
    {
        private static HomeController controller;
        private static IEnumerable<MaviBlog.Post> result;

        Establish context = () =>
        {
            var repository = MockRepository.GenerateStub<IPostRepository>();
            var mapper = MockRepository.GenerateStub<IMappingEngine>();

            controller = new HomeController(repository, mapper);
        };

        Because of = () =>
            result = controller.Index().Posts;

        It should_properly_handle_the_request = () =>
        {


        };
    }
}