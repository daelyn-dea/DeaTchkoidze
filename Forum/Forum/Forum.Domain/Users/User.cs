using Forum.Domain.Comments;
using Forum.Domain.Topics;
using Microsoft.AspNetCore.Identity;

namespace Forum.Domain.Users
{
    public class User : IdentityUser, IBaseEntity
	{
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
		public string? LastName { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? BlockedTime { get; set; }
        public bool IsBlocked { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Topic>? Topics { get; set; }
		public virtual ICollection<Comment>? Comments { get; set; }
	}
}
