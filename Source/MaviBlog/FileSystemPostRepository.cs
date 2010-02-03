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
            return GetAllPosts();
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
    }
}