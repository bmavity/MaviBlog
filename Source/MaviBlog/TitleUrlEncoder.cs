using System;

namespace MaviBlog
{
    public class TitleUrlEncoder : ITitleUrlEncoder
    {
        public string EncodeTitle(string postTitle)
        {
            var encodedTitle = postTitle
                .Replace(" ", "-")
                .Replace(".", String.Empty)
                .Replace("?", String.Empty)
                .Replace("!", String.Empty)
                .Replace("(", String.Empty)
                .Replace(")", String.Empty)
                .ToLower();

            while(encodedTitle.Contains("--"))
            {
                encodedTitle = encodedTitle.Replace("--", "-");
            }

            return encodedTitle;
        }
    }
}