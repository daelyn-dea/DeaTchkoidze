// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.AspNetCore.Http;

namespace Forum.Application.Images
{
    public interface IImagesRepository
    {
        Task SaveImageAsync(IFormFile image, string savePath, string imageUrl, CancellationToken cancellationToken);
    }
}
