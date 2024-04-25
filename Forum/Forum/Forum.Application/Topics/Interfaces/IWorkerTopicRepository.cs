// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Topics.Interfaces
{
    public interface IWorkerTopicRepository
    {
        Task InactivateTopic(CancellationToken cancellationToken);
    }
}
