using Forum.Application.Exceptions;
using Forum.Application.Topics.RequestModels;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Topics.UserServices;
using Forum.Application.Topics;
using Forum.Domain.Topics;
using HashidsNet;
using Microsoft.Extensions.Configuration;
using Mapster;
using Forum.Application.Helpers;
using Forum.Application.Images;
using Forum.Application.Users.UserServices;

public class UserTopicService : IUserTopicService
{
    private readonly ITopicRepository _topicRepository;
    private readonly IHashids _hashIds;
    private readonly IConfiguration _configuration;
    private readonly IImagesRepository _imagesRepository;
    private readonly IUserService _userService;

    public UserTopicService(ITopicRepository topicRepository, IHashids hashIds, IConfiguration configuration, IImagesRepository imagesRepository, IUserService userService)
    {
        _topicRepository = topicRepository;
        _hashIds = hashIds;
        _configuration = configuration;
        _imagesRepository = imagesRepository;
        _userService = userService;
    }

    public async Task<PagedList<UserTopicDetailsModel>> GetAllTopicsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var topics = await _topicRepository
            .GetAllTopicsForUserAsync(pageNumber, pageSize, cancellationToken)
            .ConfigureAwait(false);

        return topics.Adapt<PagedList<UserTopicDetailsModel>>(); ;

    }

    public async Task CreateTopicAsync(TopicRequestModel topic, string id, CancellationToken cancellationToken)
    {
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

            ImageFileHelper.GenerateUrl(topic.Image.FileName, savePath, out imageName, out imageUrl);

            await _imagesRepository.SaveImageAsync(topic.Image, savePath, imageUrl, cancellationToken).ConfigureAwait(false);

            dbTopic.ImageUrl = $"{requestPath}/{imageName}";
        }

        await _topicRepository.CreateTopicAsync(dbTopic, cancellationToken).ConfigureAwait(false);
    }

    public async Task<PagedList<ImagedTopicModel>> GetTopicAsync(int pageNumber, int pageSize, string id, CancellationToken cancellationToken)
    {
        var topicId = DecodeAndValidateTopicId(id);
        var topicForResponse = await _topicRepository.GetTopicAsync(pageNumber, pageSize, topicId, cancellationToken).ConfigureAwait(false);

        if (topicForResponse == null)
            throw new TopicNotFoundException();

        var topicResponseModelForUser = topicForResponse!.Adapt<PagedList<ImagedTopicModel>>();

        return topicResponseModelForUser;
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
