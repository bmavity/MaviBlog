using System.Collections.Generic;

namespace MaviBlog
{
    public interface IPostRepository
    {
        IEnumerable<PostViewModel> GetLatestPosts();
        PostViewModel GetPostById(long id);
        long Save(Post postToCreate);
    }
}