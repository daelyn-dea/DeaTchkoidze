// Copyright (C) TBC Bank. All Rights Reserved.

using Forum.Application.Infrastructure.Exceptions;

namespace Forum.Application.Infrastructure.Helpers
{
    public static class ImageFileHelper
    {
        public static void GenerateUrl(string fileName, string savePath, out string imageName, out string imageUrl)
        {
            var extensions = Path.GetExtension(fileName).ToLower();
            var validExtensions = new string[] { ".jpg", ".png", ".jpeg" };

            if (!validExtensions.Contains(extensions))
                throw new InvalidFormatException();

            var guid = Guid.NewGuid().ToString();
            imageName = guid + extensions;
            imageUrl = Path.Combine(savePath, imageName);
        }
    }
}
