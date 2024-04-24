// Copyright (C) TBC Bank. All Rights Reserved.

namespace Forum.Application.Comments.ResponseModels
{
    public class CommentResponseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string? UserImageUrl { get; set; }
    }
}
