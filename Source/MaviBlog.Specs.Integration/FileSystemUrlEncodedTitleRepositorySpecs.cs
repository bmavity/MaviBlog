using System.IO;
using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace MaviBlog.Specs.Integration
{
    public class FileSystemUrlEncodedTitleRepositorySpecs {}

    [Subject(typeof(FileSystemUrlEncodedTitleRepository)), Tags("developer", "creating post")]
    public class when_adding_the_first_map_entry : empty_repository
    {
        Because of = () =>
            repository.SaveUrlToPostIdMap("save-me", 1);

        It should_create_the_data_file = () =>
            dataFile.ShouldExist();

        It should_contain_the_first_entry = () =>
            repository.GetPostIdForUrlEncodedTitle("save-me").ShouldEqual(1);
    }

    [Subject(typeof(FileSystemUrlEncodedTitleRepository)), Tags("developer", "creating post")]
    public class when_adding_additional_map_entries : empty_repository
    {
        Establish context = () =>
        {
            repository.SaveUrlToPostIdMap("first-entry", 1);
        };

        Because of = () =>
            repository.SaveUrlToPostIdMap("second-entry", 2);

        It should_contain_the_first_entry = () =>
            repository.GetPostIdForUrlEncodedTitle("first-entry").ShouldEqual(1);

        It should_contain_the_second_entry = () =>
            repository.GetPostIdForUrlEncodedTitle("second-entry").ShouldEqual(2);
    }

    public class empty_repository
    {
        protected static FileSystemUrlEncodedTitleRepository repository;
        protected static string dataFile = "UrlToPostIdMap.data";

        Establish context = () =>
        {
            repository = new FileSystemUrlEncodedTitleRepository(dataFile);
        };

        Cleanup after_all = () =>
        {
            File.Delete(dataFile);
        };
    }
}
// ReSharper restore InconsistentNaming