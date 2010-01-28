namespace MaviBlog.Web.Controllers.Post
{
    public class PostController
    {
        public SinglePostViewModel Index()
        {
            return new SinglePostViewModel();
        }

        public SinglePostViewModel Individual(string seoFriendlyName)
        {
            return new SinglePostViewModel
            {
                Author = "Brian Mavity",
                Text = "<p>This is the first paragraph.</p><p>This is the second paragraph.</p>",
                Title = seoFriendlyName,
            };
        }
    }

    public class SinglePostViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}