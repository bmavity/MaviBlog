using System;

namespace MaviBlog
{
    public class TitleUrlEncoder : ITitleUrlEncoder
    {
        public string EncodeTitle(string postTitle)
        {
            return postTitle
                .Replace(" ", "-")
                .Replace("?", String.Empty)
                .Replace("!", String.Empty)
                .Replace("(", String.Empty)
                .Replace(")", String.Empty)
                .ToLower();
        }
    }
}