namespace MaviBlog
{
    public interface IUrlEncodedTitleRepository
    {
        long GetPostIdForUrlEncodedTitle(string urlEncodedTitle);
        void SaveUrlToPostIdMap(string urlEncodedTitle, long postId);
    }
}