// Copyright (C) TBC Bank. All Rights Reserved.

using System.Security.Claims;
using Forum.Application.Topics.UserServices;
using Microsoft.AspNetCore.Mvc;
using Forum.Application.Topics.RequestModels;
using Microsoft.AspNetCore.Authorization;

namespace Forum.Web.Controllers.User
{
    public class UserTopicController : Controller
    {
        private readonly IUserTopicService _topicService;

        public UserTopicController(IUserTopicService topicService) => _topicService = topicService;

        public async Task<IActionResult> GetTopicById(string id, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 5)
        {
            var topicResponse = await _topicService.GetTopicAsync(pageNumber, pageSize, id, cancellationToken).ConfigureAwait(false);

            return View(topicResponse);
        }

        public async Task<IActionResult> GetTopics(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 5)
        {
            var topics = await _topicService.GetAllTopicsAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
            return View(topics);
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(string body, IFormFile? image, CancellationToken cancellationToken)
        {
            var topicRequestModel = new TopicRequestModel
            {
                Title = body,
                Image = image
            };
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _topicService.CreateTopicAsync(topicRequestModel, userId!, cancellationToken).ConfigureAwait(false);

            return RedirectToAction("Index", "Home");
        }
    }
}
