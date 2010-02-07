using Machine.Specifications;

// ReSharper disable InconsistentNaming
namespace MaviBlog.Specs.Core
{
    public class TitleUrlEncoderSpecs {}

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_capital_letters : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("ThisIsThePostTitleWithCapitalLetters");

        It should_make_all_capital_letters_lowercase = () =>
            encodedTitle.ShouldEqual("thisistheposttitlewithcapitalletters");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_spaces : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("this is a title with spaces");

        It should_replace_all_spaces_with_dashes = () =>
            encodedTitle.ShouldEqual("this-is-a-title-with-spaces");
    }

    public class url_encoder
    {
        protected static TitleUrlEncoder encoder;
        protected static string encodedTitle;

        Establish context = () =>
        {
            encoder = new TitleUrlEncoder();
        };
    }
}
// ReSharper restore InconsistentNaming