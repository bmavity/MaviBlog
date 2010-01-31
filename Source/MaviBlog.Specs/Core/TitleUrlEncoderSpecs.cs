using Machine.Specifications;

namespace MaviBlog.Specs.Core
{
    public class TitleUrlEncoderSpecs {}

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_capital_letters
    {
        private static TitleUrlEncoder encoder;
        private static string encodedTitle;

        Establish context = () =>
        {
            encoder = new TitleUrlEncoder();
        };

        Because of = () =>
            encodedTitle = encoder.EncodeTitle("ThisIsThePostTitleWithCapitalLetters");

        It should_make_all_capital_letters_lowercase = () =>
            encodedTitle.ShouldEqual("thisistheposttitlewithcapitalletters");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_spaces
    {
        private static TitleUrlEncoder encoder;
        private static string encodedTitle;

        Establish context = () =>
        {
            encoder = new TitleUrlEncoder();
        };

        Because of = () =>
            encodedTitle = encoder.EncodeTitle("this is a title with spaces");

        It should_replace_all_spaces_with_dashes = () =>
            encodedTitle.ShouldEqual("this-is-a-title-with-spaces");
    }
}