using System.Collections.Generic;

namespace MaviBlog.Web.Controllers.Home
{
    public class HomeViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}