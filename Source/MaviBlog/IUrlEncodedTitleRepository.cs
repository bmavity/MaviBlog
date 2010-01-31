namespace MaviBlog
{
    public interface IUrlEncodedTitleRepository
    {
        long GetPostIdForUrlEncodedTitle(string testPostName);
    }
}