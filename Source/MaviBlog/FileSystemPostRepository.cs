using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace MaviBlog
{
    public class FileSystemPostRepository : IPostRepository
    {
        private readonly string _filePath;

        public FileSystemPostRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<PostViewModel> GetLatestPosts()
        {
            return _postViews;
        }

        public PostViewModel GetPostById(long id)
        {
            return GetAllPosts()
                .ElementAt((int) id - 1);
        }

        public long Save(Post postToCreate)
        {
            CreateFileIfItDoesNotExist();
            var nextId = GetAllPosts().Count() + 1;
            using (var writer = GetFileWriter())
            {
                writer.WriteLine(new JavaScriptSerializer().Serialize(postToCreate));
                writer.Close();
            }
            return nextId;
        }

        private StreamWriter GetFileWriter()
        {
            return new StreamWriter(_filePath, true);
        }

        private IEnumerable<PostViewModel> GetAllPosts()
        {
            var posts = new List<PostViewModel>();
            using (var reader = new StreamReader(_filePath))
            {
                while(!reader.EndOfStream)
                {
                    posts.Add(new JavaScriptSerializer().Deserialize<PostViewModel>(reader.ReadLine()));
                }
                reader.Close();
            }
            return posts;
        }

        private void CreateFileIfItDoesNotExist()
        {
            if (!File.Exists(_filePath))
            {
                using (File.Create(_filePath)) ;
            }
        }




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