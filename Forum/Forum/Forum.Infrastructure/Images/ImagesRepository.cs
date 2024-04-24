// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Images;
using Microsoft.AspNetCore.Http;

namespace Forum.Infrastructure.Images
{
    public class ImagesRepository : IImagesRepository
    {
        public async Task SaveImageAsync(IFormFile image, string savePath, string imageUrl, CancellationToken cancellationToken)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath); 

            using var stream = new FileStream(imageUrl, FileMode.Create);

            await image.CopyToAsync(stream, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
