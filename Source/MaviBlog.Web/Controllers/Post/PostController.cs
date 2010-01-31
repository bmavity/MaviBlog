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

        public PostViewModel Get(PostIndexInputModel inputModel)
        {
            return _repository.GetPostByUrlEncodedTitle(inputModel.UrlFormattedPostTitle);
        }

        [JsonEndpoint]
        public PostCreateResult Post(PostCreateInputModel inputModel)
        {
            var postId = _repository.Save(new MaviBlog.Post());
            return new PostCreateResult
            {
                Id = postId,
            };
        }
    }
}