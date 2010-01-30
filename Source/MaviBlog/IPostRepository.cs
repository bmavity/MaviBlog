using System.Collections.Generic;

namespace MaviBlog
{
    public interface IPostRepository
    {
        IEnumerable<PostViewModel> GetLatestPosts();
        PostViewModel GetPostByUrlEncodedTitle(string urlEncodedPostTitle);
    }
}