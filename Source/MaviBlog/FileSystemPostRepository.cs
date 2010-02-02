using System;
using System.Collections.Generic;
using System.IO;
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
            throw new NotImplementedException();
        }

        public PostViewModel GetPostById(long id)
        {
            using (var reader = new StreamReader(_filePath))
            {
                var post = new JavaScriptSerializer().Deserialize<PostViewModel>(reader.ReadLine());
                reader.Close();
                return post;
            }
        }

        public long Save(Post postToCreate)
        {
            using (var writer = GetFileWriter())
            {
                writer.WriteLine(new JavaScriptSerializer().Serialize(postToCreate));
                writer.Close();
            }
            return 1;
        }

        private StreamWriter GetFileWriter()
        {
            if (!File.Exists(_filePath))
            {
                return new StreamWriter(File.Create(_filePath));
            }
            return new StreamWriter(_filePath, true);
        }
    }
}