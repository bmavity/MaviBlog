namespace MaviBlog
{
    public class TitleUrlEncoder : ITitleUrlEncoder
    {
        public string EncodeTitle(string postTitle)
        {
            return postTitle
                .Replace(" ", "-")
                .ToLower();
        }
    }
}