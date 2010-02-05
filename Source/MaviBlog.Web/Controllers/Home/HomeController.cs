using FubuMVC.Core;

namespace MaviBlog.Web.Controllers.Home
{
    public class HomeController
    {
        private readonly IPostRepository _repository;
        private readonly ITitleUrlEncoder _urlEncoder;

        public HomeController(IPostRepository repository, ITitleUrlEncoder urlEncoder)
        {
            _repository = repository;
            _urlEncoder = urlEncoder;
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

            var posts = _repository.GetLatestPosts();
            posts.Each(x => x.UrlEncodedTitle = _urlEncoder.EncodeTitle(x.Title));

            return new HomeViewModel
            {
                Posts = posts,
            };
        }
    }
}
