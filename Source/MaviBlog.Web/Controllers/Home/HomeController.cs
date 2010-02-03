using MaviBlog.Web.Controllers.Post;
using StructureMap;

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
            //var posts = ObjectFactory.GetInstance<PostController>();
            //posts.Post(new PostCreateInputModel
            //{
            //    Author = "George RR Martin",
            //    Content = "<h1>I'm still not finished</h1>",
            //    PublishDate = "10/15/2090",
            //    Title = "A Dance With Dragons",
            //});

            //posts.Post(new PostCreateInputModel
            //{
            //    Author = "Brian Mavity",
            //    Content = "<h1>I'm still not blogging</h1>",
            //    PublishDate = "7/5/2010",
            //    Title = "*sadface*",
            //});

            return new HomeViewModel
            {
                Posts = _repository.GetLatestPosts(),
            };
        }
    }
}
