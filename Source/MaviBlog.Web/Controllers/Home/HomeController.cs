using System.Collections.Generic;

namespace MaviBlog.Web.Controllers.Home
{
    public class HomeController
    {
        private readonly IPostRepository _repository;

        public HomeController(IPostRepository repository)
        {
            _repository = repository;
        }

        public HomeViewModel Index()
        {
            return new HomeViewModel
            {
                Posts = _repository.GetLatestPosts(),
            };
        }
    }

    public class HomeViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
