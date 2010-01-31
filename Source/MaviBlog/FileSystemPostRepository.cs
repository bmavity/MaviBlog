using System;
using System.Collections.Generic;

namespace MaviBlog
{
    public class FileSystemPostRepository : IPostRepository
    {
        public IEnumerable<PostViewModel> GetLatestPosts()
        {
            throw new NotImplementedException();
        }

        public PostViewModel GetPostById(long id)
        {
            throw new NotImplementedException();
        }

        public long Save(Post postToCreate)
        {
            throw new NotImplementedException();
        }
    }
}