using System.IO;
using Machine.Specifications;

// ReSharper restore InconsistentNaming
namespace MaviBlog.Specs.Integration
{
    public class FileSystemPostRepositorySpecs {}

    [Subject("An empty FileSystemPostRepository"), Tags("developer", "creating post")]
    public class when_saving_a_post : empty_post_repository
    {
        private static long postId;
        private static readonly Post postToSave = new Post
        {
            Author = "George RR Martin",
            Content = "<h1>I'm still not finished</h1>",
            PublishDate = "10/15/2090",
            Title = "A Dance With Dragons",
        };

        Because of = () =>
            postId = repository.Save(postToSave);

        It should_create_the_data_file = () =>
            dataFile.ShouldExist();

        It should_set_the_post_id_to_one = () =>
            postId.ShouldEqual(1);

        It should_contain_the_first_entry = () =>
            repository.GetPostById(postId).ShouldMatch(postToSave);
    }

    [Subject("FileSystemPostRepository that contains posts"), Tags("developer", "creating post")]
    public class when_saving_an_additional_post : empty_post_repository
    {
        private static long firstPostId;
        private static long additionalPostId;
        private static readonly Post firstPost = new Post
        {
            Author = "George RR Martin",
            Content = "<h1>I'm still not finished</h1>",
            PublishDate = "10/15/2090",
            Title = "A Dance With Dragons",
        };

        private static readonly Post additionalPost = new Post
        {
            Author = "Brian Mavity",
            Content = "<h1>I'm still not blogging</h1>",
            PublishDate = "7/5/2010",
            Title = "*sadface*",
        };

        Establish context = () =>
        {
            firstPostId = repository.Save(firstPost);
        };

        Because of = () =>
            additionalPostId = repository.Save(additionalPost);

        It should_increment_the_id_for_the_additional_post = () =>
            additionalPostId.ShouldEqual(2);

        It should_contain_the_additional_entry = () =>
            repository.GetPostById(additionalPostId).ShouldMatch(additionalPost);

        It should_contain_the_first_entry = () =>
            repository.GetPostById(firstPostId).ShouldMatch(firstPost);
    }

    public class empty_post_repository
    {
        protected static FileSystemPostRepository repository;
        protected static string dataFile = "Posts.data";

        Establish context = () =>
        {
            repository = new FileSystemPostRepository(dataFile);
        };

        Cleanup after_all = () =>
        {
            File.Delete(dataFile);
        };
    }
}
// ReSharper restore InconsistentNaming