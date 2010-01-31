using System;

namespace MaviBlog
{
    public class FileSystemUrlEncodedTitleRepository : IUrlEncodedTitleRepository
    {
        public long GetPostIdForUrlEncodedTitle(string urlEncodedTitle)
        {
            return 1;
        }

        public void SaveUrlToPostIdMap(string urlEncodedTitle, long postId)
        {
            throw new NotImplementedException();
        }
    }
}