using Machine.Specifications;

namespace MaviBlog.Specs
{
    public class BlogSpecs{}

    [Subject(typeof(Blog))]
    public class a_new_blog
    {
        private static Blog newBlog;

        Establish context = () => newBlog = null;

        Because of = () => newBlog = new Blog();

        It should_not_be_null = () =>
        {
            newBlog.ShouldNotBeNull();
        };
    }
}
