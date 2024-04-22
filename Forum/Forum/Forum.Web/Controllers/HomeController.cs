// Copyright (C) TBC Bank. All Rights Reserved.

using System.Text;
using Forum.Application.Topics.AdminServices;
using Forum.Application.Topics.UserServices;
using Forum.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserTopicService _topicService;
        private readonly IAdminTopicService _adminTopicService;

        public HomeController(IUserTopicService topicService, IAdminTopicService adminTopicService)
        {
            _topicService = topicService;
            _adminTopicService = adminTopicService;
        }

        public IActionResult Index()
        {
            if (User != null && User.IsInRole("Admin"))
            {
                return RedirectToAction("GetTopics", "ManageTopic");
            }
            else
            {
                return RedirectToAction("GetTopics", "UserTopic");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var model = new ErrorViewModel();
            var errorMessage = Encoding.UTF8.GetString(HttpContext.Session.Get("ErrorMessage"));

            if (errorMessage != null)
                model.ErrorMessage = errorMessage;

            return View(model);
        }
    }
}
