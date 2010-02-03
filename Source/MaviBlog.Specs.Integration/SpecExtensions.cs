using System.Collections.Generic;
using System.IO;
using Machine.Specifications;
using System.Linq;
using Machine.Specifications.Utility;
using MaviBlog.Specs.Integration;

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

        public static void ShouldOnlyContain(this IEnumerable<PostViewModel> candidate, params Post[] actual)
        {
            candidate.Count().ShouldEqual(actual.Count());
            actual.Each(x => candidate.FirstOrDefault(y => y.Matches(x)).ShouldNotBeNull());
        }

        public static bool Matches(this PostViewModel candidate, Post actual)
        {
            if (candidate.Author != actual.Author) return false;
            if (candidate.Content != actual.Content) return false;
            if (candidate.PublishDate != actual.PublishDate) return false;
            return candidate.Title == actual.Title;
        }
    }
}