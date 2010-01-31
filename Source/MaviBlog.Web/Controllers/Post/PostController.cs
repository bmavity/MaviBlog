using FubuMVC.Core;

namespace MaviBlog.Web.Controllers.Post
{
    public class PostController
    {
        private readonly IPostRepository _postRepository;
        private readonly IUrlEncodedTitleRepository _titleRepository;

        public PostController(IPostRepository postRepository, IUrlEncodedTitleRepository titleRepository)
        {
            _postRepository = postRepository;
            _titleRepository = titleRepository;
        }

        public PostViewModel Get(PostIndexInputModel inputModel)
        {
            var postId = _titleRepository.GetPostIdForUrlEncodedTitle(inputModel.UrlFormattedPostTitle);
            return _postRepository.GetPostById(postId);
        }

        [JsonEndpoint]
        public PostCreateResult Post(PostCreateInputModel inputModel)
        {
            var postId = _postRepository.Save(new MaviBlog.Post
                                                  {
                                                      Author = inputModel.Author,
                                                      Title = inputModel.Title,
                                                  });
            return new PostCreateResult
            {
                Id = postId,
            };
        }
    }
}