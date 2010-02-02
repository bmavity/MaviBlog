using System.IO;
using Machine.Specifications;

// ReSharper restore InconsistentNaming
namespace MaviBlog.Specs.Integration
{
    public class FileSystemPostRepositorySpecs {}

    [Subject(typeof(FileSystemPostRepository)), Tags("developer", "creating post")]
    public class when_saving_the_first_post : empty_post_repository
    {
        private static long postId;
        private static Post postToSave = new Post
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

        It should_contain_the_first_entry = () =>
            repository.GetPostById(postId).ShouldMatch(postToSave);
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