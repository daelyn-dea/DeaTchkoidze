using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Topics.RequestModels;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Topics.UserServices;
using Forum.Domain.Topics;
using HashidsNet;
using Microsoft.Extensions.Configuration;
using Mapster;
using Forum.Application.Images;
using Forum.Application.Users.UserServices;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Infrastructure.Helpers;

public class UserTopicService : IUserTopicService
{
    private readonly IUserTopicRepository _topicRepository;
    private readonly IHashids _hashIds;
    private readonly IConfiguration _configuration;
    private readonly IImagesRepository _imagesRepository;
    private readonly IUserService _userService;

    public UserTopicService(IUserTopicRepository topicRepository, IHashids hashIds, IConfiguration configuration, IImagesRepository imagesRepository, IUserService userService)
    {
        _topicRepository = topicRepository;
        _hashIds = hashIds;
        _configuration = configuration;
        _imagesRepository = imagesRepository;
        _userService = userService;
    }

    public async Task<PagedList<UserTopicDetailsModel>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        if (pageNumber <= 0)
            throw new PageNotFoundException();

        var topics = await _topicRepository
            .GetAllTopicsAsync(pageNumber, pageSize, cancellationToken)
            .ConfigureAwait(false);

        if (pageNumber > topics.TotalPages)
            throw new PageNotFoundException();

        return topics.Adapt<PagedList<UserTopicDetailsModel>>();
    }

    public async Task<PagedList<ImagedTopicModel>> GetTopicAsync(int pageNumber, int pageSize, string id, CancellationToken cancellationToken)
    {
        if (pageNumber <= 0)
            throw new PageNotFoundException();

        var topicId = DecodeAndValidateTopicId(id);

        var topicForResponse = await _topicRepository
            .GetTopicAsync(pageNumber, pageSize, topicId, cancellationToken)
            .ConfigureAwait(false);

        if (pageNumber > topicForResponse.TotalPages)
            throw new PageNotFoundException();

        return topicForResponse!.Adapt<PagedList<ImagedTopicModel>>();
    }

    public async Task CreateTopicAsync(TopicRequestModel topic, string id, CancellationToken cancellationToken)
    {
        if (topic.Title == null)
            throw new NotAllowedWriteTopicException();

        var canAddPost = await _userService
            .AccessOfPostTopic(id, cancellationToken)
            .ConfigureAwait(false);

        if (!canAddPost)
        {
            throw new NotAllowedWriteTopicException();
        }
        var dbTopic = topic.Adapt<Topic>();
        dbTopic.UserId = id;

        if (topic.Image != null && topic.Image.Length > 0)
        {
            var savePath = _configuration.GetValue<string>("TopicImagesConfiguration:SavePath");
            var requestPath = _configuration.GetValue<string>("TopicImagesConfiguration:RequestPath");

            string imageName, imageUrl;
            ImageFileHelper.GenerateUrl(topic.Image!.FileName, savePath, out imageName, out imageUrl);

            await _imagesRepository.SaveImageAsync(topic.Image, savePath, imageUrl, cancellationToken).ConfigureAwait(false);

            dbTopic.ImageUrl = $"{requestPath}/{imageName}";
        }

        await _topicRepository.CreateTopicAsync(dbTopic, cancellationToken).ConfigureAwait(false);
    }

    public async Task<bool> ExistsTopic(int id, CancellationToken cancellationToken)
    {
        return await _topicRepository.ExistsTopic(id, cancellationToken).ConfigureAwait(false);
    }

    private int DecodeAndValidateTopicId(string id)
    {
        var intIds = _hashIds.Decode(id);
        if (intIds.Length == 0)
        {
            throw new TopicNotFoundException();
        }
        return intIds[0];
    }

    public async Task<bool> CanDelete(int id, string userId, CancellationToken cancellationToken)
    {
        return await _topicRepository.CanDelete(id, userId, cancellationToken).ConfigureAwait(false);
    }
}
