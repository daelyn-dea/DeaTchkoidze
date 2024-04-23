// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Topics.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Forum.Application.Topics.UserServices;
using Forum.Application.Topics.RequestModels;
using Asp.Versioning;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Infrastructure.Exceptions;

namespace Forum.API.Controllers.User
{
    /// <summary>
    /// Controller for managing topics by users in the forum API.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/user-topic")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "User")]
    public class UserTopicController : ControllerBase
    {
        private readonly IUserTopicService _topicService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserTopicController"/> class.
        /// </summary>
        /// <param name="topicService">The service for managing user topics.</param>
        public UserTopicController(IUserTopicService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// Retrieves all topics for the current user.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of user topic details.</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<PagedList<UserTopicDetailsModel>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _topicService.GetAllTopicsAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a specific topic with comments by topicID.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The size of each page.</param>
        /// <param name="id">The ID of the topic to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A paged list of imaged topic models.</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<PagedList<ImagedTopicModel>> Get(int pageNumber, int pageSize, string id, CancellationToken cancellationToken)
        {
            return await _topicService.GetTopicAsync(pageNumber, pageSize, id, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new topic.
        /// </summary>
        /// <param name="topic">The model containing the data for the new topic.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [HttpPost]
        public async Task Post([FromForm] TopicRequestModel topic, CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UserNotFoundException();

            await _topicService.CreateTopicAsync(topic, userId, cancellationToken).ConfigureAwait(false);
        }
    }
}
