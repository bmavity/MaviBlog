﻿using FubuMVC.Core;

namespace MaviBlog.Web.Controllers.Post
{
    public class PostIndexInputModel
    {
        [RouteInput]
        public string UrlEncodedPostTitle { get; set; }
    }
}