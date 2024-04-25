// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Forum.Application.Topics.ResponseModels.TopicResponseStateEnum;
using static Forum.Domain.Topics.TopicStatusEnum;

namespace Forum.Web.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminTopicController : Controller
    {
        private readonly IAdminTopicService _topicService;

        public AdminTopicController(IAdminTopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopics(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 15)
        {
            var topicsForAdmin = await _topicService.GetAllTopicsAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
            return View(topicsForAdmin);
        }

        [HttpGet]
        public async Task<IActionResult> GetTopicById(string id, CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 15)
        {
            var topic = await _topicService.GetTopicAsync(pageNumber, pageSize, id, cancellationToken).ConfigureAwait(false);
            return View(topic);
        }

        public async Task<IActionResult> ChangeState(string topicId, TopicState state, CancellationToken cancellationToken)
        {
            await _topicService.ChangeState(topicId, state, cancellationToken).ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangeStatus(string topicId, TopicStatus status, CancellationToken cancellationToken)
        {
            await _topicService.ChangeStatus(topicId, status, cancellationToken).ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }
    }
}
