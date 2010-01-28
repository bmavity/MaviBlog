using System;
using System.Collections.Generic;

namespace MaviBlog
{
    public class PostRepository : IPostRepository
    {
        public IEnumerable<PostViewModel> GetLatestPosts()
        {
            return new[]
                       {
                           new PostViewModel
                               {
                                   //Author = "Brian Mavity",
                                   //Content =
                                   //    "<p>And with that age old (relatively speaking) tradition of uselessness " +
                                   //    "from the web, I open myself to the world.</p> <h2>Why a blog?</h2> <p>I " +
                                   //    "feel that developers need to have both strong oral and written communication " +
                                   //    "skills. I decided that by making a " +
                                   //    "<a href=\"http://www.codinghorror.com/blog/archives/000983.html\">commitment to blogging</a>" +
                                   //    ", I could reap what I consider to be major benefits.</p> " +
                                   //    "<ul> <li>Improve my writing skills by... writing</li> " +
                                   //    "<li>Improve my level of knowledge by researching posts</li> " +
                                   //    "<li>Get to know others in the community by providing informative posts</li> " +
                                   //    "<li>Improve my development skills by interacting with others in the community</li> " +
                                   //    "</ul> <h2>Which way do I lean?</h2> <p>Not like that... pervs! I am a .net developer, " +
                                   //    "and I feel like our community can be broadly",
                                   //PublishDate = "Friday, September 05 2008",
                                   //Title = "First!",
                               },
                           new PostViewModel
                               {
                                   //Author = "Brian Mavity",
                                   //Content = "<p>This is the shiz</p>",
                                   //PublishDate = "December 17, 2009",
                                   //Title = "Second!",
                               },
                       };

        }
    }
}