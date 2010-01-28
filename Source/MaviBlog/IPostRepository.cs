using System.Collections.Generic;

namespace MaviBlog
{
    public interface IPostRepository
    {
        IEnumerable<PostViewModel> GetLatestPosts();
    }

    public class PostViewModel
    {
    }
}