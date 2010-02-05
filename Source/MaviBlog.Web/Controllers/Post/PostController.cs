using FubuMVC.Core;

namespace MaviBlog.Web.Controllers.Post
{
    public class PostController
    {
        private readonly IPostRepository _postRepository;
        private readonly ITitleUrlEncoder _encoder;
        private readonly IUrlEncodedTitleRepository _titleRepository;

        public PostController(IPostRepository postRepository, ITitleUrlEncoder encoder, IUrlEncodedTitleRepository titleRepository)
        {
            _postRepository = postRepository;
            _encoder = encoder;
            _titleRepository = titleRepository;
        }

        public PostViewModel Get(PostIndexInputModel inputModel)
        {
            var postId = _titleRepository.GetPostIdForUrlEncodedTitle(inputModel.UrlEncodedPostTitle);
            var post = _postRepository.GetPostById(postId);
            post.UrlEncodedTitle = inputModel.UrlEncodedPostTitle;
            return post;
        }

        [JsonEndpoint]
        public PostCreateResult Post(PostCreateInputModel inputModel)
        {
            var postId = _postRepository.Save(new MaviBlog.Post
                                                  {
                                                      Author = inputModel.Author,
                                                      Content = inputModel.Content,
                                                      PublishDate = inputModel.PublishDate,
                                                      Title = inputModel.Title,
                                                  });
            var encodedTitle = _encoder.EncodeTitle(inputModel.Title);
            _titleRepository.SaveUrlToPostIdMap(encodedTitle, postId);
            return new PostCreateResult
            {
                Id = postId,
            };
        }
    }
}