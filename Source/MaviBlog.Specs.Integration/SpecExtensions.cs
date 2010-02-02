using System.IO;
using Machine.Specifications;

namespace MaviBlog.Specs.Integration
{
    public static class SpecExtensions
    {
        public static void ShouldExist(this string filePath)
        {
            File.Exists(filePath).ShouldBeTrue();
        }

        public static void ShouldMatch(this PostViewModel candidate, Post actual)
        {
            candidate.Author.ShouldEqual(actual.Author);
            candidate.Content.ShouldEqual(actual.Content);
            candidate.PublishDate.ShouldEqual(actual.PublishDate);
            candidate.Title.ShouldEqual(actual.Title);
        }
    }
}