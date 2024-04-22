// Copyright (C) TBC Bank. All Rights Reserved.

using Microsoft.AspNetCore.Http;

namespace Forum.Application.Users.Models.UpdateModel
{
    public class UpdateModel
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public IFormFile? Image { get; set; }
    }
}
