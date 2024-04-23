// Copyright (C) TBC Bank. All Rights Reserved.

using Asp.Versioning;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.AdminServices;
using Forum.Application.Topics.ResponseModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Forum.Application.Topics.ResponseModels.TopicResponseStateEnum;
using static Forum.Domain.Topics.TopicStatusEnum;

namespace Forum.API.Controllers.Admin
{
    /// <summary>
    /// Controller for managing topic-related operations by admins in the forum API.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/manage-topics")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class ManageTopicController : ControllerBase
    {
        private readonly IAdminTopicService _topicService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageTopicController"/> class.
        /// </summary>
        /// <param name="topicService">The service for managing admin topic operations.</param>
        public ManageTopicController(IAdminTopicService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// Retrieves all topics, with count of comments.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of admin topic details.</returns>
        [HttpGet]
        public async Task<PagedList<AdminTopicDetailsModel>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _topicService.GetAllTopicsAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet("{id}")]
        public async Task<PagedList<AdminImagedTopicModel>> Get(int pageNumber, int pageSize, string id, CancellationToken cancellationToken)
        {
            return await _topicService.GetTopicAsync(pageNumber, pageSize, id, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the state of a topic. 
        /// </summary>
        /// <param name="topicId">The ID of the topic.</param>
        /// <param name="state">The new state of the topic. Show - 1 / Hide - 2 </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [HttpPost("state")]
        public async Task ChangeState(string topicId, TopicState state, CancellationToken cancellationToken)
        {
            await _topicService.ChangeState(topicId, state, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Changes the status of a topic.
        /// </summary>
        /// <param name="topicId">The ID of the topic.</param>
        /// <param name="status">The new status of the topic.Active - 0 / Inactive - 1 </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [HttpPost("status")]
        public async Task ChangeStatus(string topicId, TopicStatus status, CancellationToken cancellationToken)
        {
            await _topicService.ChangeStatus(topicId, status, cancellationToken).ConfigureAwait(false);
        }
    }
}
