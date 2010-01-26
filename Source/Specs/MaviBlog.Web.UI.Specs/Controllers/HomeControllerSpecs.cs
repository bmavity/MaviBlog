using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Machine.Specifications;
using MaviBlog.Web.UI.Controllers;
using Rhino.Mocks;

namespace MaviBlog.Web.UI.Specs
{
    public class HomeControllerSpecs {}

    [Subject(typeof(HomeController))]
    public class home_controller_when_handling_request
    {
        private static HomeController controller;
        private static IEnumerable<SinglePostViewModel> result;

        Establish context = () =>
        {
            var repository = MockRepository.GenerateStub<IPostRepository>();
            var mapper = MockRepository.GenerateStub<IMappingEngine>();

            controller = new HomeController(repository, mapper);
        };

        Because of = () =>
            result = controller.Index().Model as IEnumerable<SinglePostViewModel>;

        It should_properly_handle_the_request = () =>
        {


        };
    }
}