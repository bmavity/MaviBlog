using System;
using System.Collections.Generic;
using System.Linq;

namespace MaviBlog
{
    public class InMemoryPostRepository : IPostRepository
    {
        public IEnumerable<PostViewModel> GetLatestPosts()
        {
            return _postViews;
        }

        public PostViewModel GetPostById(long id)
        {
            var matchingPost = _posts[(int) (id - 1)];
            return new PostViewModel
                       {
                           Author = matchingPost.Author,
                           Content = matchingPost.Content,
                           PublishDate = matchingPost.PublishDate,
                           Title = matchingPost.Title,
                       };
        }

        public long Save(Post postToCreate)
        {
            _posts.Add(postToCreate);
            return _posts.Count;
        }

        public static void Reset()
        {
            _posts.Clear();
        }

        private static List<Post> _posts = new List<Post>();

        private static IEnumerable<PostViewModel> _postViews = new[]
                       {
                           new PostViewModel
                               {
                                   Author = "Brian Mavity",
                                   Content =
                                       "<p>And with that age old (relatively speaking) tradition of uselessness " +
                                       "from the web, I open myself to the world.</p> <h3>Why a blog?</h3> <p>I " +
                                       "feel that developers need to have both strong oral and written communication " +
                                       "skills. I decided that by making a " +
                                       "<a href=\"http://www.codinghorror.com/blog/archives/000983.html\">commitment to blogging</a>" +
                                       ", I could reap what I consider to be major benefits.</p> " +
                                       "<ul> <li>Improve my writing skills by... writing</li> " +
                                       "<li>Improve my level of knowledge by researching posts</li> " +
                                       "<li>Get to know others in the community by providing informative posts</li> " +
                                       "<li>Improve my development skills by interacting with others in the community</li> " +
                                       "</ul> <h3>Which way do I lean?</h3> <p>Not like that... pervs! I am a .net developer, " +
                                       "and I feel like our community can be broadly",
                                   PublishDate = "Friday, September 5 2008",
                                   Title = "First!",
                               },
                           new PostViewModel
                               {
                                   Author = "Brian Mavity",
                                   Content = "<p>This is the shiz</p>",
                                   PublishDate = "December 17, 2009",
                                   Title = "Second!",
                               },
                       };
    }
}