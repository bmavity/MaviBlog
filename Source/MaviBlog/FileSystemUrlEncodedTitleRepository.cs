using System;
using System.IO;

namespace MaviBlog
{
    public class FileSystemUrlEncodedTitleRepository : IUrlEncodedTitleRepository
    {
        private readonly string _filePath;

        public FileSystemUrlEncodedTitleRepository(string filePath)
        {
            _filePath = filePath;
        }

        public long GetPostIdForUrlEncodedTitle(string urlEncodedTitle)
        {
            using(var reader = new StreamReader(_filePath))
            {
                while(!reader.EndOfStream)
                {
                    var entry = reader.ReadLine().GetEntry();
                    if(entry.EncodedUrl() == urlEncodedTitle)
                    {
                        reader.Close();
                        return entry.Id();
                    }
                }
            }
            return -1;
        }

        public void SaveUrlToPostIdMap(string urlEncodedTitle, long postId)
        {
            using(var writer = GetFileWriter())
            {
                writer.WriteLine(urlEncodedTitle + " " + postId);
                writer.Close();
            }
        }

        public StreamWriter GetFileWriter()
        {
            if (!File.Exists(_filePath))
            {
                return new StreamWriter(File.Create(_filePath));
            }
            return new StreamWriter(_filePath, true);
        }
    }

    public static class UrlEncodedRepositoryExtensions
    {
        public static string[] GetEntry(this string fileLine)
        {
            return fileLine.Split(' ');
        }

        public static string EncodedUrl(this string[] entry)
        {
            return entry[0];
        }

        public static long Id(this string[] entry)
        {
            return Int64.Parse(entry[1]);
        }
    }
}