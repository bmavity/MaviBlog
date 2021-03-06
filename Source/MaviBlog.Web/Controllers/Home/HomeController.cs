﻿using System;
using FubuMVC.Core;
using System.Linq;

namespace MaviBlog.Web.Controllers.Home
{
    public class HomeController
    {
        private readonly IPostRepository _repository;
        private readonly ITitleUrlEncoder _urlEncoder;

        public HomeController(IPostRepository repository, ITitleUrlEncoder urlEncoder)
        {
            _repository = repository;
            _urlEncoder = urlEncoder;
        }

        public HomeViewModel Index()
        {
            var posts = _repository.GetLatestPosts()
                .OrderByDescending(x => DateTime.Parse(x.PublishDate));
            posts.Each(x => x.UrlEncodedTitle = _urlEncoder.EncodeTitle(x.Title));

            return new HomeViewModel
            {
                Posts = posts,
            };
        }
    }
}
