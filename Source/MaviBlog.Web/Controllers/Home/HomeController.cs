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
}
