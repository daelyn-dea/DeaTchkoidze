// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Users.Interfaces
{
    public interface IWorkerUserRepository
    {
        Task BlockExpiration(CancellationToken cancellationToken);
    }
}
