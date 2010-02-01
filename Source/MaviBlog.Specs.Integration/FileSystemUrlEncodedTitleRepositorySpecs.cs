using System.IO;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace MaviBlog.Specs.Integration
{
    public class FileSystemUrlEncodedTitleRepositorySpecs {}

    [Subject(typeof(FileSystemUrlEncodedTitleRepository)), Tags("developer", "creating post")]
    public class when_creating_first_map_entry
    {
        private static FileSystemUrlEncodedTitleRepository repository;
        private static string dataFile = "UrlToPostIdMap.data";

        Establish context = () =>
        {
            repository = new FileSystemUrlEncodedTitleRepository(dataFile);
        };

        Cleanup after = () =>
        {
            File.Delete(dataFile);
        };

        Because of = () =>
            repository.SaveUrlToPostIdMap("save-me", 1);

        It should_create_the_data_file = () =>
            dataFile.ShouldExist();

        It should_be_able_to_find_the_entry = () =>
            repository.GetPostIdForUrlEncodedTitle("save-me");
    }
}
// ReSharper restore InconsistentNaming