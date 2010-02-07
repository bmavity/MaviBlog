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

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_question_marks : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("howmany?canwehave?");

        It should_remove_all_question_marks = () =>
            encodedTitle.ShouldEqual("howmanycanwehave");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_exclamation_points : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("howmany!canwehave!");

        It should_remove_all_exclamation_points = () =>
            encodedTitle.ShouldEqual("howmanycanwehave");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_periods : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("howmany.canwehave.");

        It should_remove_all_periods = () =>
            encodedTitle.ShouldEqual("howmanycanwehave");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_prenthesis : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("i(can)has(parens)");

        It should_remove_all_opening_and_closing_parenthesis = () =>
            encodedTitle.ShouldEqual("icanhasparens");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_colons : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("i:can:hascolons:");

        It should_remove_all_colons = () =>
            encodedTitle.ShouldEqual("icanhascolons");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_single_quotes : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("i'mhas'ing'single'quotes");

        It should_replace_all_single_quotes_with_dashes = () =>
            encodedTitle.ShouldEqual("i-mhas-ing-single-quotes");
    }

    [Subject(typeof(TitleUrlEncoder))]
    public class when_encoding_a_title_with_multiple_dashes_next_to_each_other : url_encoder
    {
        Because of = () =>
            encodedTitle = encoder.EncodeTitle("i--have---multiple--dashes");

        It should_replace_all_multiple_dashes_with_single = () =>
            encodedTitle.ShouldEqual("i-have-multiple-dashes");
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