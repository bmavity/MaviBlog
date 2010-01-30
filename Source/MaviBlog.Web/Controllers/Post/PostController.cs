using FubuMVC.Core;

namespace MaviBlog.Web.Controllers.Post
{
    public class PostController
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [UrlPattern("post/{UrlFormattedPostTitle}")]
        public PostViewModel Index(PostIndexInputModel inputModel)
        {
            return _repository.GetPostByUrlEncodedTitle(inputModel.UrlFormattedPostTitle);
        }
    }
}