namespace MaviBlog.Specs.Integration
{
    public class InMemoryUrlEncodedTitleRepository : IUrlEncodedTitleRepository
    {
        public long GetPostIdForUrlEncodedTitle(string testPostName)
        {
            return 1;
        }
    }
}