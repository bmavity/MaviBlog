using System;
using System.Web.Mvc;

namespace MaviBlog.Web.UI.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Individual(string seoFriendlyName)
        {
            return View(new SinglePostViewModel
            {
                Author = "Brian Mavity",
                Text = "<p>This is the first paragraph.</p><p>This is the second paragraph.</p>",
                Title = seoFriendlyName,
            });
        }
    }

    public class SinglePostViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}