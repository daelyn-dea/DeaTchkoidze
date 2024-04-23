// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Images;
using Forum.Application.Infrastructure.Exceptions;
using Forum.Application.Infrastructure.Helpers;
using Forum.Application.Topics.Interfaces;
using Forum.Application.Topics.RequestModels;
using Forum.Application.Topics.ResponseModels;
using Forum.Application.Users.UserServices;
using Forum.Domain.Topics;
using HashidsNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Forum.Application.Tests.Topics
{
    public class UserTopicServiceTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<IUserTopicRepository> _topicRepository;
        private readonly Mock<IHashids> _hashIds;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IImagesRepository> _imagesRepository;
        private readonly Mock<IFormFile> _formFileMock;

        public UserTopicServiceTests()
        {
            _topicRepository = new Mock<IUserTopicRepository>();
            _userService = new Mock<IUserService>();
            _imagesRepository = new Mock<IImagesRepository>();
            _hashIds = new Mock<IHashids>();
            _configuration = new Mock<IConfiguration>();
            _formFileMock = new Mock<IFormFile>();
        }

        [Fact]
        public async Task GetTopicAsync_WhenTopicExists_ShouldReturnedPagedListOfImagedTopicModel()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 3;
            var count = 0;
            var id = "testdata";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] {1});

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1,  CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var action = await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.NotNull(action);
            Assert.IsType<PagedList<ImagedTopicModel>>(action);
            _topicRepository.Verify(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task GetTopicAsync_WhenTopicDoesNotExists_ShouldThrowTopicNotFoundException()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 3;
            var count = 0;
            var id = "negativeData";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] { 1 });

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var task = async () => await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            var exception = await Assert.ThrowsAsync<TopicNotFoundException>(task).ConfigureAwait(false);
        }

        [Fact]
        public async Task GetTopicAsync_WhenCountIs1AndPageSize1AndPageNumber1_ShouldReturn4PageAndHasNotNextPageAndPreviousPage()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 1;
            var count = 1;
            var id = "testdata";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] { 1 });

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(1, result.TotalPages);
            Assert.False(result.HasPreviousPage);
            Assert.False(result.HasNextPage);
        }

        [Fact]
        public async Task GetTopicAsync_WhenCountIs20AndPageSize5AndPageNumber1_ShouldReturn4PageAndHasNextPage()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;
            var count = 20;
            var id = "testdata";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] { 1 });

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result =  await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.False(result.HasPreviousPage);
            Assert.True(result.HasNextPage);
        }

        [Fact]
        public async Task GetTopicAsync_WhenCountIs20AndPageSize5AndPageNumber2_ShouldReturn4PageAndHasNextPageAndPreviousPage()
        {
            // Arrange
            var pageNumber = 2;
            var pageSize = 5;
            var count = 20;
            var id = "testdata";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] { 1 });

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.True(result.HasPreviousPage);
            Assert.True(result.HasNextPage);
        }

        [Fact]
        public async Task GetTopicAsync_WhenCountIs20AndPageSize5AndPageNumber4_ShouldReturn4PageAndHasNotNextPage()
        {
            // Arrange
            var pageNumber = 4;
            var pageSize = 5;
            var count = 20;
            var id = "testdata";

            var pagedTopic = new PagedList<Topic>(new Topic(), count, pageNumber, pageSize);

            _hashIds.Setup(x => x.Decode("testdata")).Returns(new int[1] { 1 });

            _topicRepository.Setup(x => x.GetTopicAsync(pageNumber, pageSize, 1, CancellationToken.None))
                                .ReturnsAsync(pagedTopic);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetTopicAsync(pageNumber, pageSize, id, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.True(result.HasPreviousPage);
            Assert.False(result.HasNextPage);
        }

        [Fact]
        public async Task GetAllTopicsAsync_WhenCountIs22AndPageSize10AndTopicsExist_HaveToReturnPAgedListOdUserTopicDetailsModel()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 3;
            var count = 2;

            var topicsFromRepository = new PagedList<TopicWithCommentCount>(new List<TopicWithCommentCount>()
            {
                new TopicWithCommentCount()
                {
                    UserImageUrl = "/Default",
                    CommentCount = 2,
                    Topic = new Topic()
                    {
                        Id = 1,
                        ImageUrl = "/Default",
                        Comments = null,
                        CreatedAt = DateTime.UtcNow,
                        State = TopicStateEnum.DbTopicState.Show,
                        Status = TopicStatusEnum.TopicStatus.Active,
                        Title = "Title",
                        UpdatedAt = DateTime.UtcNow,
                        UserId = "2e116f02-a263-4287-a499-d776cc30c592"

                    },
                    UserName = "dea"
                }
            }, count, pageNumber, pageSize);

            _topicRepository.Setup(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None))
                                .ReturnsAsync(topicsFromRepository);

            _hashIds.Setup(x => x.Encode(1)).Returns("7B0Yzw4J");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PagedList<UserTopicDetailsModel>>(result);
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);

            _topicRepository.Verify(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task GetAllTopicsAsync_WhenCountIs20AndPageSize5AndPageNumber4_ShouldReturn4PageAndHasNotNextPageHasPreviousPage()
        {
            // Arrange
            var pageNumber = 4;
            var pageSize = 5;
            var count = 20;

            var topicsFromRepository = new PagedList<TopicWithCommentCount>(new List<TopicWithCommentCount>()
            {
                new TopicWithCommentCount()
            }, count, pageNumber, pageSize);

            _topicRepository.Setup(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None))
                                .ReturnsAsync(topicsFromRepository);

            _hashIds.Setup(x => x.Encode(1)).Returns("7B0Yzw4J");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.True(result.HasPreviousPage);
            Assert.False(result.HasNextPage);
        }

        [Fact]
        public async Task GetAllTopicsAsync_WhenCountIs20AndPageSize5AndPageNumber1_ShouldReturn4PageAndHasNotNextPageHasPreviousPage()
        {
            // Arrange
            var pageNumber = 4;
            var pageSize = 5;
            var count = 20;

            var topicsFromRepository = new PagedList<TopicWithCommentCount>(new List<TopicWithCommentCount>()
            {
                new TopicWithCommentCount()
            }, count, pageNumber, pageSize);

            _topicRepository.Setup(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None))
                                .ReturnsAsync(topicsFromRepository);

            _hashIds.Setup(x => x.Encode(1)).Returns("7B0Yzw4J");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.True(result.HasPreviousPage);
            Assert.False(result.HasNextPage);
        }

        [Fact]
        public async Task GetAllTopicsAsync_WhenCountIs20AndPageSize5AndPageNumber2_ShouldReturn4PageAndHasNextPageHasPreviousPage()
        {
            // Arrange
            var pageNumber = 2;
            var pageSize = 5;
            var count = 20;

            var topicsFromRepository = new PagedList<TopicWithCommentCount>(new List<TopicWithCommentCount>()
            {
                new TopicWithCommentCount()
            }, count, pageNumber, pageSize);

            _topicRepository.Setup(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None))
                                .ReturnsAsync(topicsFromRepository);

            _hashIds.Setup(x => x.Encode(1)).Returns("7B0Yzw4J");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(4, result.TotalPages);
            Assert.True(result.HasPreviousPage);
            Assert.True(result.HasNextPage);
        }

        [Fact]
        public async Task GetAllTopicsAsync_WhenCountIs1AndPageSize1AndPageNumber1_ShouldReturn4PageAndHasNotNextPageAndPreviousPage()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 1;
            var count = 1;

            var topicsFromRepository = new PagedList<TopicWithCommentCount>(new List<TopicWithCommentCount>()
            {
                new TopicWithCommentCount()
            }, count, pageNumber, pageSize);

            _topicRepository.Setup(x => x.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None))
                                .ReturnsAsync(topicsFromRepository);

            _hashIds.Setup(x => x.Encode(1)).Returns("7B0Yzw4J");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.GetAllTopicsAsync(pageNumber, pageSize, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.Equal(pageNumber, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(count, result.TotalCount);
            Assert.Equal(1, result.TotalPages);
            Assert.False(result.HasPreviousPage);
            Assert.False(result.HasNextPage);
        }

        [Fact]
        public async Task CreateTopicAsync_WhenUserHaveAccessToCreateTopicAndTopicHaveImage_HaveToRunSaveImageAsyncMethod()
        {
            // Arrange
            _userService
                .Setup(x => x.AccessOfPostTopic(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _formFileMock.Setup(x => x.FileName).Returns("test.jpg");
            _formFileMock.Setup(x => x.Length).Returns(123);
            _formFileMock.Setup(x => x.ContentType).Returns("image/jpeg");

            var inMemorySettings = new Dictionary<string, string>
            {
                     {"TopicImagesConfiguration:SavePath", "C:\\Users\\dchko\\Desktop\\Visual Studio Files\\.NET\\Forum\\TopicImages"},
                     {"TopicImagesConfiguration:RequestPath", "/TopicImages"},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var save =  configuration
                .GetValue<string>("TopicImagesConfiguration:SavePath");

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, configuration, _imagesRepository.Object, _userService.Object);

            var topic = new TopicRequestModel()
            {
                Image = _formFileMock.Object,
                Title = "Something"
            };

            // Act 
            await topicService.CreateTopicAsync(topic, "Random", CancellationToken.None).ConfigureAwait(false);

            // Assert
            _imagesRepository.Verify(x => x.SaveImageAsync(It.IsAny<IFormFile>(), save, It.IsAny<string>(), CancellationToken.None), Times.Once);
            _topicRepository.Verify(x => x.CreateTopicAsync(It.IsAny<Topic>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task CreateTopicAsync_WhenUserHaveAccessToCreateTopicAndTopicHasNoImage_ShouldNotRunSaveImageAsync()
        {
            // Arrange
            _userService
                .Setup(x => x.AccessOfPostTopic(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            var topic = new TopicRequestModel()
            {
                Image = null,
                Title = "Something"
            };

            var save = "savePath";

            // Act 
            await topicService.CreateTopicAsync(topic, "Random", CancellationToken.None).ConfigureAwait(false);

            // Assert
            _imagesRepository.Verify(x => x.SaveImageAsync(It.IsAny<IFormFile>(), save, It.IsAny<string>(), CancellationToken.None), Times.Never);
            _topicRepository.Verify(x => x.CreateTopicAsync(It.IsAny<Topic>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task CreateTopicAsync_WhenUserDoesNotHaveAccessToWriteTopic_ShouldThrowNotAllowedWriteTopicException()
        {
            _userService
                .Setup(x => x.AccessOfPostTopic(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            var topic = new TopicRequestModel()
            {
                Image = null,
                Title = "Something"
            };

            // Act & Assert
            await Assert.ThrowsAsync<NotAllowedWriteTopicException>(() =>
                 topicService.CreateTopicAsync(topic, "Random", CancellationToken.None))
                .ConfigureAwait(false);
        }

        [Fact]
        public async Task ExistsTopic_WhenUserExists_ShouldReturnedTrue()
        {
            //arrange
            _topicRepository.Setup(x => x.ExistsTopic(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(true);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.ExistsTopic(1, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ExistsTopic_WhenUserDoesNot_ShouldReturnedFalse()
        {
            //arrange
            _topicRepository.Setup(x => x.ExistsTopic(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(false);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.ExistsTopic(1, CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CanDelete_WhenUserCantAccessDeleteComment_ShouldReturnedFalse()
        {
            //arrange
            _topicRepository.Setup(x => x.CanDelete(It.IsAny<int>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(false);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.CanDelete(1, "RandomUser", CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CanDelete_WhenUserCanAccessDeleteComment_ShouldReturnedTrue()
        {
            //arrange
            _topicRepository.Setup(x => x.CanDelete(It.IsAny<int>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(true);

            var topicService = new UserTopicService(_topicRepository.Object, _hashIds.Object, _configuration.Object, _imagesRepository.Object, _userService.Object);

            // Act
            var result = await topicService.CanDelete(1, "RandomUser", CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.True(result);
        }
    }
}
